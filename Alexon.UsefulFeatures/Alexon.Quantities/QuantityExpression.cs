using System.Linq.Expressions;

namespace Alexon.Quantities
{
    public class QuantityExpression<L,R> where L : Quantity where R : Quantity
    {
        public QuantityExpression(Expression<Func<L, R, Quantity>> value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value), "Expression cannot be null.");
        }

        public Expression<Func<L, R, Quantity>> Value { get; internal set; }
        public static implicit operator Expression<Func<Quantity, Quantity,Quantity>>(QuantityExpression<L,R> expression)
        {
            var clone = Expression.Lambda<Func<Quantity, Quantity, Quantity>>(
                expression.Value.Body,
                expression.Value.Parameters[0],
                expression.Value.Parameters[1]);

            return clone;
        }

        public static QuantityExpression<L, R> operator /(QuantityExpression<L, R> left, Quantity right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left), "Left expression cannot be null.");
            if (right is null) throw new ArgumentNullException(nameof(right), "Right quantity cannot be null.");
            var body = Expression.Divide(left.Value.Body, Expression.Constant(right, typeof(Quantity)));
            var parameters = left.Value.Parameters;
            var lambda = Expression.Lambda<Func<L, R, Quantity>>(body, parameters);
        
            return new QuantityExpression<L, R>(lambda);
        }
    }
}
