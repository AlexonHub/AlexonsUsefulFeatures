using Alexon.Formulas;
using Alexon.Quantities.Prefixes;
using System.Globalization;
using System.Linq.Expressions;

namespace Alexon.Quantities
{

    public class Quantity
    {
        public virtual string Measure { get; } = string.Empty;
        public virtual string Description { get; } = string.Empty;
        public virtual string DimensionSymbol { get; } = string.Empty;
        public virtual string QuantitySymbol { get; } = string.Empty;

        protected string? unitSymbol;

        public virtual string UnitSymbol
        {
            get
            {
                return NaturalDegree > 1 || NaturalDegree < 0? $"{FormatUnitSymbol()}^{NaturalDegree}" : $"{FormatUnitSymbol()}" ?? string.Empty;
            }

            set => unitSymbol = value;
        }

        private string FormatUnitSymbol() => unitSymbol is not null && (unitSymbol.Contains('/') || unitSymbol.Contains('*'))
                ? $"({unitSymbol})"
                : $"{unitSymbol}";

        public Prefix Prefix { get; set; } = new Base();
        public virtual int NaturalDegree { get; set; } = 1;
        
        public virtual double QuantityValue { get; set; }

        public double MetricValue
        {
            get
            {
                if (NaturalDegree == 0 || Prefix.Power == 0)
                {
                    return Prefix.Get(QuantityValue);
                }
                var denominator = (double)Math.Pow(10, NaturalDegree * Prefix.Power);
                return QuantityValue / denominator;
            }

            set => QuantityValue = Prefix.Set(value);
        }
        public string MetricUnitSymbol => Prefix.Symbol + UnitSymbol;
        public SimpleExpression? ConversionExpression { get; set; } = null!; 
        public Expression<Func<double, double>>? ConversionFormula { get; set; } = null; 
        public Expression<Func<double, double>>? InversedConversionFormula
        {
            get
            {
                if (ConversionFormula is null) return null;
                Expression body = ((BinaryExpression)ConversionFormula.Body).RevertExpression();
                var revertedFormula = Expression.Lambda<Func<double, double>>(body, ConversionFormula.Parameters[0]);
                return revertedFormula;
            }
        }

        public Expression<Func<Quantity, Quantity, Quantity>>? Formula { get; set; }

        override public string ToString()
        {
            if (string.IsNullOrEmpty(UnitSymbol))
            {
                return QuantitySymbol;
            }

            return $"{QuantitySymbol} = {MetricValue.ToString(CultureInfo.InvariantCulture)} {Prefix.Symbol}{UnitSymbol}";
        }

        public virtual Quantity ToMetric<P>() where P : Prefix, new()
        {
            var newQuantity = ShallowCopy();
            newQuantity.Prefix = new P();
            newQuantity.SetToDecimalConversionFormula();
            newQuantity.QuantityValue = QuantityValue;
            return newQuantity;
        }

        public Q To<Q>() where Q : Quantity, new()
        {
            var simpleExpression = ConversionFactor.GetFormula(GetType(), typeof(Q));
            double value = simpleExpression is not null ? (double)simpleExpression.Calculate((double)QuantityValue) : QuantityValue;
            var quantity =  new Q()
            {
                NaturalDegree = NaturalDegree,
                Prefix = Prefix,
                QuantityValue = value,
                ConversionExpression = simpleExpression,
                ConversionFormula = simpleExpression.OneParamFunc
            };
            return quantity;
        }

        #region Operators

        public static implicit operator double(Quantity quantity) => quantity.QuantityValue;
        //public static explicit operator Quantity(double value) => Length<T>.Set(value);

        public static Quantity operator *(Quantity left, Quantity right)
        {
            if (left.Measure == right.Measure)
            {
                return left.OperationWithSameType(Operation.Multiply, right);
            }

            return left.OperationWithDifferentTypes<DerivedQuantity>(Operation.Multiply, right);
        }
        public static Quantity operator *(Quantity left, double number)
        {
            var quantity = left.ShallowCopy();
            quantity.QuantityValue *= number;
            return quantity;
        }

        public static Quantity operator /(Quantity left, Quantity right)
        {
            if (right.QuantityValue == 0) throw new DivideByZeroException("Cannot divide by zero.");

            if (left.Measure == right.Measure)
            {
                return left.OperationWithSameType(Operation.Divide, right);
            }

            return left.OperationWithDifferentTypes<DerivedQuantity>(Operation.Divide, right);
        }
        public static Quantity operator /(Quantity left, double number)
        {
            if (number == 0) throw new DivideByZeroException("Cannot divide by zero.");
            var quantity = left.ShallowCopy();
            quantity.QuantityValue /= number;
            return quantity;
        }
        
        public static Quantity operator +(Quantity left, Quantity right)
        {
            if (left.Measure != right.Measure)
            {
                throw new InvalidOperationException($"Cannot add quantities of different measures: {left.Measure} and {right.Measure}.");
            }
            var quantity = left.ShallowCopy();
            quantity.QuantityValue += right.QuantityValue;
            return quantity;
        }
        public static Quantity operator +(Quantity left, double right)
        {
            var quantity = left.ShallowCopy();
            quantity.QuantityValue += right;
            return quantity;
        }

        public static Quantity operator -(Quantity left, Quantity right)
        {
            if (left.Measure != right.Measure)
            {
                throw new InvalidOperationException($"Cannot subtract quantities of different measures: {left.Measure} and {right.Measure}.");
            }
            var quantity = left.ShallowCopy();
            quantity.QuantityValue -= right.QuantityValue;
            return quantity;
        }
        public static Quantity operator -(Quantity left, double right)
        {
            var quantity = left.ShallowCopy();
            quantity.QuantityValue -= right;
            return quantity;
        }

        public static bool operator ==(Quantity left, double right)
        {
            return left.QuantityValue == right;
        }

        public static bool operator !=(Quantity left, double right)
        {
            return left.QuantityValue != right;
        }

        public static bool operator ==(Quantity left, Quantity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Quantity left, Quantity right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Quantity quantity &&
                   Measure == quantity.Measure &&
                   NaturalDegree == quantity.NaturalDegree &&
                   QuantityValue == quantity.QuantityValue &&
                   Prefix.Power == quantity.Prefix.Power;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Measure);
            hash.Add(Description);
            hash.Add(DimensionSymbol);
            hash.Add(QuantitySymbol);
            hash.Add(unitSymbol);
            hash.Add(UnitSymbol);
            hash.Add(Prefix);
            hash.Add(NaturalDegree);
            hash.Add(QuantityValue);
            return hash.ToHashCode();
        }

        public Quantity ShallowCopy() => (Quantity)MemberwiseClone();

        #endregion
    }
}