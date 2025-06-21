using System.Linq.Expressions;

namespace Alexon.Quantities
{
    public static class ExpressionExtensions
    {
        public static BinaryExpression GetOperationExpression(this Operation operation, Expression left, Expression right)
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
        public static Expression RevertExpression(this BinaryExpression body)
        {
            Expression? revertedFormula = body.NodeType == ExpressionType.Divide
                ? Expression.Multiply(body.Left, body.Right)
                : Expression.Divide(body.Left, body.Right);
            return (BinaryExpression)revertedFormula;
        }

    }
}
