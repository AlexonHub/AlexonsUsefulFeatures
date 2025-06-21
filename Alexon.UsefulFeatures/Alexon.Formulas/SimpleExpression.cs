using System.Linq.Expressions;

namespace Alexon.Formulas
{
    public class SimpleExpression
    {
        public Expression? Left { get; set; }
        public double? LeftValue { get; set; } = null;
        public Expression? Right { get; set; }
        public double? RightValue { get; set; } = null;
        public double Result { get; set; }

        public ExpressionType NodeType { get; set; }

        public BinaryExpression? Formula
        {
            get
            {
                if (Left is null || Right is null) return null;
                BinaryExpression binaryExpression = Expression.MakeBinary(NodeType, Left, Right);
                return binaryExpression;
            }
        }


        public Expression<Func<double, double>>? OneParamFunc
        {
            get
            {
                if (Formula is null) return null;

                if (Left.NodeType == ExpressionType.Parameter && Right.NodeType == ExpressionType.Constant)
                {
                    return Expression.Lambda<Func<double, double>>(Formula, (ParameterExpression)Left);
                }
                else if (Left.NodeType == ExpressionType.Constant && Right.NodeType == ExpressionType.Parameter)
                {
                    return Expression.Lambda<Func<double, double>>(Formula, (ParameterExpression)Right);
                }
                return null; 
            }
        }

        public Expression<Func<double, double>>? LeftInversedOneParamFunc
        {
            get
            {
                if (OneParamFunc is null) return null;
                Expression? body = RevertExpression((BinaryExpression)OneParamFunc.Body);
                if (body is null)
                {
                    return null;
                }
                var revertedFormula = Expression.Lambda<Func<double, double>>(body, OneParamFunc.Parameters[0]);
                return revertedFormula;
            }
        }

        public Expression<Func<double, double>>? RightInversedOneParamFunc
        {
            get
            {
                if (LeftInversedOneParamFunc is null) return null;
                Expression? body = RevertExpression((BinaryExpression)LeftInversedOneParamFunc.Body);
                if (body is null)
                {
                    return null;
                }
                var revertedFormula = Expression.Lambda<Func<double, double>>(body, LeftInversedOneParamFunc.Parameters[0]);
                return revertedFormula;
            }
        }

        public Expression<Func<double, double, double>>? TwoParamFunc
        {
            get
            {
                if (Formula is null) return null;

                if (Left?.NodeType == ExpressionType.Parameter && Right?.NodeType == ExpressionType.Parameter)
                {
                    return Expression.Lambda<Func<double, double, double>>(Formula, (ParameterExpression)Left, (ParameterExpression)Right);
                }
                return null;
            }
        }

        public Expression<Func<double, double, double>>? LeftInversedTwoParamFunc
            {
            get
            {
                if (TwoParamFunc is null) return null;
                Expression? body = RevertExpression((BinaryExpression)TwoParamFunc.Body);
                if (body is null)
                {
                    return null;
                }
                var revertedFormula = Expression.Lambda<Func<double, double, double>>(body, TwoParamFunc.Parameters[0], TwoParamFunc.Parameters[1]);
                return revertedFormula;
            }
        }

        public double Calculate(double left, double? right = null)
        {
            LeftValue = left;
            RightValue = right;

            if (OneParamFunc != null)
            {
                Result =  OneParamFunc.Compile().Invoke(left);
                RightValue = (Right as ConstantExpression)?.Value as double?;
                return Result;
            }
            else if (TwoParamFunc != null)
            {
                if (right.HasValue)
                {
                    Result = TwoParamFunc.Compile().Invoke(left, right.Value);
                    return Result; 
                }
                throw new ArgumentException("Right parameter is required for two-parameter functions.");
            }
            throw new InvalidOperationException("No valid function to calculate.");
        } 
        
        public override string ToString()
        {
            if (OneParamFunc != null)
            {
                return OneParamFunc.ToString();
            }
            else if (TwoParamFunc != null)
            {
                return TwoParamFunc.ToString();
            }
            return string.Empty;
        }
        
        public static Expression? RevertExpression(BinaryExpression body)
        {
            Expression? revertedFormula = body.NodeType switch
            {
                ExpressionType.Divide => Expression.Multiply(body.Left, body.Right),
                ExpressionType.Multiply => Expression.Divide(body.Left, body.Right),
                ExpressionType.Add => Expression.Subtract(body.Left, body.Right),
                ExpressionType.Subtract => Expression.Add(body.Left, body.Right),
                ExpressionType.Power => Root(body.Right, body.Left),
                _ => null,
            };
            return revertedFormula;
        }

        public static Expression Root(Expression index, Expression radicand)
        {
            var one = Expression.Constant(1.0, typeof(double));
            var inverseExponent = Expression.Divide(one, index);
            var power = Expression.Power(radicand, inverseExponent);
            return power;
        }

    }
}
