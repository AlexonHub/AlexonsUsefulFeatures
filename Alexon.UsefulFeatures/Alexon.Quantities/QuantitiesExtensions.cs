using System.Linq.Expressions;

namespace Alexon.Quantities
{
    public static partial class QuantitiesExtensions
    {
        public static V To<V>(this Quantity quantity, decimal value) where V : Quantity, new()
        {
            V newQuantity = new()
            {
                NaturalDegree = quantity.NaturalDegree,
                Prefix = quantity.Prefix,
                Value = quantity.Value == 0 ? quantity.Prefix.Set(value) : value
            };
            return newQuantity;
        }

        public static Quantity SetToDecimalConversionFormula(this Quantity quantity)
        {
            var factor = (decimal)Math.Pow(10, quantity.Prefix.Power);
            var left = Expression.Parameter(typeof(decimal), quantity.QuantitySymbol);
            var right = Expression.Constant(factor, typeof(decimal));
            var body = Expression.Divide(left, right);
            quantity.ConversionFormula = Expression.Lambda<Func<decimal, decimal>>(body, left);
            return quantity;
        }

        public static Quantity SetConversationValue(this Quantity quantity, decimal factor, Operation operation)
        {
            switch (operation)
            {
                case Operation.Divide:
                    quantity.Value /= factor;
                    break;
                case Operation.Multiply:
                    quantity.Value *= factor;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid operation for conversion formula: {operation}");
            }

            var left = Expression.Parameter(typeof(decimal), quantity.QuantitySymbol);
            var right = Expression.Constant(factor, typeof(decimal));

            var body = GetOperationExpression(operation, left, right);
            quantity.ConversionFormula = Expression.Lambda<Func<decimal, decimal>>(body, left);
            return quantity;
        }

        public static DerivedQuantity SetOperationFormula(this DerivedQuantity quantity, Operation operation)
        {
            var left = Expression.Parameter(typeof(Quantity), quantity.Left.QuantitySymbol);
            var right = Expression.Parameter(typeof(Quantity), quantity.Right.QuantitySymbol); 

            var body = GetOperationExpression(operation, left, right);
            quantity.Formula = Expression.Lambda<Func<Quantity, Quantity, Quantity>>(body, left, right);
            return quantity;
        }

        public static BinaryExpression GetOperationExpression(Operation operation, Expression left, Expression right)
        {
            return operation switch
            {
                Operation.Multiply => Expression.Multiply(left, right),
                Operation.Divide => Expression.Divide(left, right),
                Operation.Add => Expression.Add(left, right),
                Operation.Subtract => Expression.Subtract(left, right),
                Operation.Power => Expression.Power(left, right),
                _ => throw new InvalidOperationException($"Unknown operation: {operation}"),
            };
        }

        public static Quantity OperationWithSameType(this Quantity left, Operation operation, Quantity right)
        {
            var quantity = left.ShallowCopy();
            switch (operation)
            {
                case Operation.Multiply:
                    quantity.Value *= right.Value;
                    quantity.NaturalDegree = left.NaturalDegree + right.NaturalDegree;
                    break;
                case Operation.Divide:
                    quantity.Value /= right.Value;
                    quantity.NaturalDegree = left.NaturalDegree - right.NaturalDegree;
                    break;
                case Operation.Add:
                    quantity.Value += right.Value;
                    if (left.NaturalDegree != right.NaturalDegree)
                    {
                        throw new InvalidOperationException($"Cannot add quantities with different natural degrees: {left.NaturalDegree} and {right.NaturalDegree}");
                    }
                    break;
                case Operation.Subtract:
                    quantity.Value -= right.Value;
                    if (left.NaturalDegree != right.NaturalDegree)
                    {
                        throw new InvalidOperationException($"Cannot subtract quantities with different natural degrees: {left.NaturalDegree} and {right.NaturalDegree}");
                    }
                    break;
                case Operation.Power:
                    quantity.Value = (decimal)Math.Pow((double)left.Value, (double)right.Value);
                    quantity.NaturalDegree = left.NaturalDegree * right.NaturalDegree;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown operation: {operation}");
            }

            quantity.Prefix = left.Prefix;
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
                    quantity.Value = left.Value / right.Value;
                    quantity.UnitSymbol = $"{left.UnitSymbol}/{right.UnitSymbol}";
                    break;
                case Operation.Multiply:
                    quantity.Value = left.Value * right.Value;
                    quantity.UnitSymbol = $"{left.UnitSymbol}*{right.UnitSymbol}";
                    break;
                default:
                    break;
            }

            return quantity.SetOperationFormula(operation);
        }

    }
}
