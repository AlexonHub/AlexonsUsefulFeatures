using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresTime;
using System.Linq.Expressions;

namespace Alexon.Quantities.Derived
{
    public class Speed : DerivedQuantity
    {
        public override string Measure => "Speed";
        public override string QuantitySymbol => "v";
        public override string Description => "Length per Time";
        public override string DimensionSymbol => "L/T";
        public override string UnitSymbol => $"{Left.UnitSymbol}/{Right.UnitSymbol}";

        public static Expression<Func<Length, Time, Speed>> InitFormula()
        {
            var left = Expression.Parameter(typeof(Length), new Length().QuantitySymbol);
            var right = Expression.Parameter(typeof(Time), new Time().QuantitySymbol);

            var body = Expression.Divide(left, right);
            var lambda = Expression.Lambda<Func<Length, Time, Speed>>(body, left, right);
            return lambda;
        }

        public static Speed Init<L,T>(double value) where L : Length, new() where T : Time, new() => InitFormula().Compile()(Length<L>.Init(value), Time<T>.Init(1));
        public static Speed Init(Length length, Time time) => InitFormula().Compile()(length, time);

        public Speed To<QL, QT>() where QL : Length, new() where QT : Time, new()
        {
            var left = Left.GetType() == typeof(QL) ? Left : Left.To<QL>();
            var right = Right.GetType() == typeof(QT) ? Right : Right.To<QT>();
            var newSpeed = Init((Length)left, (Time)right);

            if (left.ConversionFormula is null && right.ConversionFormula is null)
            {
                return newSpeed;
            }

            newSpeed.MetricValue = CalculateValue(left, right);
            return newSpeed;
        }

        private double CalculateValue(Quantity left, Quantity right)
        {
            Expression numerator = null!;
            Expression leftConstant = null!;
            Expression leftParameter = null!;
            if (left.ConversionFormula is null)
            {
                numerator = Expression.Constant(left.QuantityValue, typeof(double));
            }
            else
            {
                leftConstant = ((BinaryExpression)left.ConversionFormula.Body).Right;
                leftParameter = left.ConversionFormula.Parameters[0];
            }

            Expression denominator = null!;
            Expression rightConstant = null!;
            Expression rightParameter = null!;
            if (right.ConversionFormula is null)
            {
                denominator = Expression.Constant(right.QuantityValue, typeof(double));
            }
            else
            {
                rightConstant = ((BinaryExpression)right.ConversionFormula.Body).Right;
                rightParameter = right.ConversionFormula.Parameters[0];
            }

            if (leftParameter is not null)
            {
                if (rightConstant is not null)
                {
                    numerator = Expression.Multiply(leftParameter, rightConstant);
                }
                else
                {
                    numerator = left.ConversionFormula.Body;
                }
            }

            if (rightParameter is not null)
            {
                if (leftConstant is not null)
                {
                    denominator = Expression.Multiply(rightParameter, leftConstant);
                }
                else
                {
                    denominator = right.ConversionFormula.Body;
                }
            }

            var body = Expression.Divide(numerator, denominator);
            if (body.NodeType == ExpressionType.Divide && body.Right.NodeType == ExpressionType.Divide)
            {
                var bin = ((BinaryExpression)right.ConversionFormula.Body);
                var coup = Expression.Divide(bin.Right, bin.Left);
                body = Expression.Multiply(numerator, coup);
            }

            var parameters = new List<ParameterExpression>();
            if (leftParameter is ParameterExpression lp)
            {
                parameters.Add(lp);
            }

            if (rightParameter is ParameterExpression rp)
            {
                parameters.Add(rp);
            }

            double value;
            if (parameters.Count == 2)
            {
                var lambda = Expression.Lambda<Func<double, double, double>>(body, parameters);
                value = lambda.Compile()(Left.QuantityValue, Right.QuantityValue);
            }
            else
            {
                var lambda = Expression.Lambda<Func<double, double>>(body, parameters);
                value = leftParameter is not null ? lambda.Compile()(Left.QuantityValue) : lambda.Compile()(Right.QuantityValue);
            }

            return value;
        }
    }
}
