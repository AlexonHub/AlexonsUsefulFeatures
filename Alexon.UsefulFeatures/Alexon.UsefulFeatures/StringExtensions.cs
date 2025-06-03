using System.Linq.Expressions;

namespace Alexon.UsefulFeatures
{
    public static class StringExtensions
    {
        public static Expression ToExpression(this string input)
        {
            // Example implementation for parsing a string into an Expression.
            // This is a placeholder and should be replaced with actual logic
            // to parse the string into an Expression tree.
            var parts = input.Split(' ');
            if (parts.Length < 3)
                throw new ArgumentException("Invalid expression format.");

            var left = Expression.Constant(parts[0]);
            var operatorSymbol = parts[1];
            var right = Expression.Constant(parts[2]);

            return operatorSymbol switch
            {
                "+" => Expression.Add(left, right),
                "-" => Expression.Subtract(left, right),
                "*" => Expression.Multiply(left, right),
                "/" => Expression.Divide(left, right),
                _ => throw new NotSupportedException($"Operator '{operatorSymbol}' is not supported.")
            };
        }
    }
}
