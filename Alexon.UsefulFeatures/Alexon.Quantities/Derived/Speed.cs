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

        public static Speed Init<L,T>(decimal value) where L : Length, new() where T : Time, new() => InitFormula().Compile()(Length<L>.Init(value), Time<T>.Init(1));
        public static Speed Init(Length length, Time time) => InitFormula().Compile()(length, time);

        public Speed To<QL, QT>() where QL : Length, new() where QT : Time, new()
        {
            var length = Left.To<QL>();
            var time = Right.To<QT>();

            if (length.ConversionFormula is null && time.ConversionFormula is null)
            {
                return Init(length, time);
            }

            Expression numerator = null!;
            Expression leftConstant = null!;
            Expression leftParameter = null!;
            if (length.ConversionFormula is null)
            { 
                numerator = Expression.Constant(length.Value, typeof(decimal));
            }
            else
            {
                leftConstant = ((BinaryExpression)length.ConversionFormula.Body).Right;
                leftParameter = length.ConversionFormula.Parameters[0]; 
            }

            Expression denominator = null!;
            Expression rightConstant = null!;
            Expression rightParameter = null!;
            if (time.ConversionFormula is null)
            {
                denominator = Expression.Constant(time.Value, typeof(decimal));
            }
            else
            {
                rightConstant = ((BinaryExpression)time.ConversionFormula.Body).Right;
                rightParameter = time.ConversionFormula.Parameters[0];
            }

            if (leftParameter is not null)
            {
                if (rightConstant is not null)
                {
                    numerator = Expression.Multiply(leftParameter, rightConstant);
                }
                else
                { 
                    numerator = length.ConversionFormula.Body;
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
                    denominator = time.ConversionFormula.Body;
                }
            }

            var body = Expression.Divide(numerator, denominator);
            if(body.NodeType == ExpressionType.Divide && body.Right.NodeType == ExpressionType.Divide)
            {
                var bin = ((BinaryExpression)time.ConversionFormula.Body);
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

            decimal value;
            if (parameters.Count == 2)
            {
                var lambda = Expression.Lambda<Func<decimal, decimal, decimal>>(body, parameters);
                value = lambda.Compile()(Left.Value, Right.Value);
            }
            else
            {
                var lambda = Expression.Lambda<Func<decimal, decimal>>(body, parameters);
                value = leftParameter is not null ? lambda.Compile()(Left.Value) : lambda.Compile()(Right.Value);
            }

            var newSpeed = Init(length, time);
            newSpeed.MetricValue = value;
            return newSpeed;
        }

    }
}
