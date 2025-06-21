using System.Linq.Expressions;

namespace Alexon.Quantities
{
    public static partial class QuantitiesExtensions
    {
        public static V To<V>(this Quantity quantity, double value) where V : Quantity, new()
        {
            V newQuantity = new()
            {
                NaturalDegree = quantity.NaturalDegree,
                Prefix = quantity.Prefix,
                QuantityValue = quantity.QuantityValue == 0 ? quantity.Prefix.Set(value) : value
            };
            return newQuantity;
        }

        public static Quantity SetToDecimalConversionFormula(this Quantity quantity)
        {
            var factor = (double)Math.Pow(10, quantity.Prefix.Power);
            var left = Expression.Parameter(typeof(double), quantity.QuantitySymbol);
            var right = Expression.Constant(factor, typeof(double));
            var body = Expression.Divide(left, right);
            quantity.ConversionFormula = Expression.Lambda<Func<double, double>>(body, left);
            return quantity;
        }

        public static DerivedQuantity SetOperationFormula(this DerivedQuantity quantity, Operation operation)
        {
            var left = Expression.Parameter(typeof(Quantity), quantity.Left.QuantitySymbol);
            var right = Expression.Parameter(typeof(Quantity), quantity.Right.QuantitySymbol); 

            var body = operation.GetOperationExpression(left, right);
            quantity.Formula = Expression.Lambda<Func<Quantity, Quantity, Quantity>>(body, left, right);
            return quantity;
        }

        public static Quantity OperationWithSameType(this Quantity left, Operation operation, Quantity right)
        {
            var quantity = left.ShallowCopy();
            quantity.ConversionFormula = null; 

            switch (operation)
            {
                case Operation.Multiply:
                    quantity.QuantityValue = left.QuantityValue * right.QuantityValue;
                    quantity.NaturalDegree = left.NaturalDegree + right.NaturalDegree;
                    break;
                case Operation.Divide:
                    if (left.Measure == right.Measure && left.NaturalDegree == right.NaturalDegree)
                    {
                        quantity = new Quantity() { QuantityValue = left.QuantityValue / right.QuantityValue };
                    }
                    else
                    {
                        quantity.QuantityValue /= right.QuantityValue;
                        quantity.NaturalDegree = left.NaturalDegree - right.NaturalDegree;
                    }
                    break;
                case Operation.Add:
                    quantity.QuantityValue += right.QuantityValue;
                    if (left.NaturalDegree != right.NaturalDegree)
                    {
                        throw new InvalidOperationException($"Cannot add quantities with different natural degrees: {left.NaturalDegree} and {right.NaturalDegree}");
                    }
                    break;
                case Operation.Subtract:
                    quantity.QuantityValue -= right.QuantityValue;
                    if (left.NaturalDegree != right.NaturalDegree)
                    {
                        throw new InvalidOperationException($"Cannot subtract quantities with different natural degrees: {left.NaturalDegree} and {right.NaturalDegree}");
                    }
                    break;
                case Operation.Power:
                    quantity.QuantityValue = (double)Math.Pow((double)left.QuantityValue, (double)right.QuantityValue);
                    quantity.NaturalDegree = left.NaturalDegree * right.NaturalDegree;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown operation: {operation}");
            }

            if (quantity.NaturalDegree == 0) { quantity.NaturalDegree = 1; }
            return quantity;
        }

        public static DerivedQuantity OperationWithDifferentTypes<T>(this Quantity left, Operation operation, Quantity right)
            where T : DerivedQuantity, new()
        {
            var quantity = new T
            {
                Left = left.ShallowCopy(),
                Right = right.ShallowCopy(),
                Prefix = left.Prefix,
                Operator = operation,
            };

            switch (operation)
            {
                case Operation.Divide:
                    quantity.QuantityValue = left.QuantityValue / right.QuantityValue;
                    quantity.UnitSymbol = $"{left.UnitSymbol}/{right.UnitSymbol}";
                    break;
                case Operation.Multiply:
                    quantity.QuantityValue = left.QuantityValue * right.QuantityValue;
                    quantity.UnitSymbol = $"{left.UnitSymbol}*{right.UnitSymbol}";
                    break;
                default:
                    break;
            }

            return quantity.SetOperationFormula(operation);
        }

    }
}
