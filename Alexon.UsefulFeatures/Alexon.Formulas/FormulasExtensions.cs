using System.Linq.Expressions;

namespace Alexon.Formulas
{
    public static class FormulasExtensions
    {
        public static BinaryExpression GetOperationExpression(this ExpressionType operation, Expression left, Expression right)
        {
            return operation switch
            {
                ExpressionType.Multiply => Expression.Multiply(left, right),
                ExpressionType.Divide => Expression.Divide(left, right),
                ExpressionType.Add => Expression.Add(left, right),
                ExpressionType.Subtract => Expression.Subtract(left, right),
                ExpressionType.Power => Expression.Power(left, right),
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

        public static double Calculate(this SimpleExpression expression, params double[] parameters)
        {
            return expression.Calculate(parameters[0], parameters.Length > 1 ? parameters[1] : null);
        }

        public static SimpleExpression ToSimpleExpression(this string expression)
        {
            var simple = new SimpleExpression();
            (simple.Left, simple.NodeType, simple.Right) = expression.ToExpressionParts();
            return simple;
        }

        public static (string left, string operand, string right) ParseExpressionParts(this string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Expression cannot be null or empty.", nameof(expression));
            }

            var parts = expression.Split(' ');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Expression must be in the form 'Left Operand Right'.");
            }
            return (parts[0], parts[1], parts[2]);

        }

        public static (Expression left, ExpressionType expressionType , Expression right) ToExpressionParts(this string input)
            {
            var (left, operandSymbol, right) = input.ParseExpressionParts();
            Expression leftExpression = double.TryParse(left, out double leftValue) ? Expression.Constant(leftValue) : Expression.Parameter(typeof(double), left);
            ExpressionType nodeType = string.IsNullOrEmpty(operandSymbol) ? ExpressionType.Add : operandSymbol switch
            {
                "+" => ExpressionType.Add,
                "-" => ExpressionType.Subtract,
                "*" => ExpressionType.Multiply,
                "/" => ExpressionType.Divide,
                "^" => ExpressionType.Power,
                _ => throw new NotSupportedException($"Operator '{operandSymbol}' is not supported.")
            };
            Expression rightExpression = double.TryParse(right, out double rightValue) ? Expression.Constant(rightValue) : Expression.Parameter(typeof(double), right);
            return (leftExpression, nodeType, rightExpression);
        }

    }
}
