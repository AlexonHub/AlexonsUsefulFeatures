using Alexon.Quantities.Prefixes;
using System.Globalization;
using System.Linq.Expressions;

namespace Alexon.Quantities
{

    public abstract class Quantity
    {
        public abstract string Measure { get; }
        public abstract string Description { get; }
        public abstract string DimensionSymbol { get; }
        public abstract string QuantitySymbol { get; }

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
        public virtual decimal Value { get; set; }
        public decimal MetricValue
        {
            get
            {
                if (NaturalDegree == 0 || Prefix.Power == 0)
                {
                    return Prefix.Get(Value);
                }
                var denominator = (decimal)Math.Pow(10, NaturalDegree * Prefix.Power);
                return Value / denominator;
            }

            set => Value = Prefix.Set(value);
        }
        public string MetricUnitSymbol => Prefix.Symbol + UnitSymbol;
        public Expression<Func<decimal, decimal>>? ConversionFormula { get; set; } = null; 
        public Expression<Func<Quantity, Quantity, Quantity>>? Formula { get; set; }

        override public string ToString()
        {
            if (string.IsNullOrEmpty(UnitSymbol))
            {
                return QuantitySymbol;
            }

            return $"{QuantitySymbol} = {MetricValue.ToString("G29", CultureInfo.InvariantCulture)} {Prefix.Symbol}{UnitSymbol}";
        }

        public virtual Quantity ToMetric<P>() where P : Prefix, new()
        {
            var newQuantity = ShallowCopy();
            newQuantity.Prefix = new P();
            newQuantity.SetToDecimalConversionFormula();
            return newQuantity;
        }

        public Q To<Q>() where Q : Quantity, new()
        {
            var quantity = new Q()
            {
                NaturalDegree = NaturalDegree,
                Prefix = Prefix,
                Value = Value,
                ConversionFormula = ConversionFormula
            };

            Type from = GetType();
            Type to = typeof(Q);

            var factor = ConversionFactor.GetConversionFactor(from, to);
            if (factor != 1)
            {
                return (Q)quantity.SetConversationValue(factor, Operation.Multiply);
            }

            factor = ConversionFactor.GetConversionFactor(to, from);
            if (factor != 1)
            {
                return (Q)quantity.SetConversationValue(factor, Operation.Divide);
            }

            return quantity;
        }

        #region Operators

        //public static implicit operator decimal(Quantity quantity) => quantity.Value;
        //public static explicit operator Quantity(decimal value) => Length<T>.Set(value);

        public static Quantity operator *(Quantity left, Quantity right)
        {
            if (left.Measure == right.Measure)
            {
                return left.OperationWithSameType(Operation.Multiply, right);
            }

            return left.OperationWithDifferentTypes<DerivedQuantity>(Operation.Multiply, right);
        }
        public static Quantity operator *(Quantity left, decimal number)
        {
            var quantity = left.ShallowCopy();
            quantity.Value *= number;
            return quantity;
        }

        public static Quantity operator /(Quantity left, Quantity right)
        {
            if (right.Value == 0) throw new DivideByZeroException("Cannot divide by zero.");

            if (left.Measure == right.Measure)
            {
                return left.OperationWithSameType(Operation.Divide, right);
            }

            return left.OperationWithDifferentTypes<DerivedQuantity>(Operation.Divide, right);
        }
        public static Quantity operator /(Quantity left, decimal number)
        {
            if (number == 0) throw new DivideByZeroException("Cannot divide by zero.");
            var quantity = left.ShallowCopy();
            quantity.Value /= number;
            return quantity;
        }
        
        public static Quantity operator +(Quantity left, Quantity right)
        {
            if (left.Measure != right.Measure)
            {
                throw new InvalidOperationException($"Cannot add quantities of different measures: {left.Measure} and {right.Measure}.");
            }
            var quantity = left.ShallowCopy();
            quantity.Value += right.Value;
            return quantity;
        }
        public static Quantity operator +(Quantity left, decimal right)
        {
            var quantity = left.ShallowCopy();
            quantity.Value += right;
            return quantity;
        }

        public static Quantity operator -(Quantity left, Quantity right)
        {
            if (left.Measure != right.Measure)
            {
                throw new InvalidOperationException($"Cannot subtract quantities of different measures: {left.Measure} and {right.Measure}.");
            }
            var quantity = left.ShallowCopy();
            quantity.Value -= right.Value;
            return quantity;
        }
        public static Quantity operator -(Quantity left, decimal right)
        {
            var quantity = left.ShallowCopy();
            quantity.Value -= right;
            return quantity;
        }

        public static bool operator ==(Quantity left, decimal right)
        {
            return left.Value == right;
        }

        public static bool operator !=(Quantity left, decimal right)
        {
            return left.Value != right;
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
                   Value == quantity.Value &&
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
            hash.Add(Value);
            return hash.ToHashCode();
        }

        public Quantity ShallowCopy() => (Quantity)MemberwiseClone();

        #endregion
    }
}