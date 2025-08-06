using System.Linq.Expressions;

namespace Alexon.Formulas.Dimentions
{
    public record Dim
    {
        public Dim(double value)
        {
            Value = value;
            Formula = Expression.Parameter(typeof(double), Symbol);
        }

        public double Value { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual string Symbol { get; set; } = string.Empty;
        public Expression Formula { get; set; } = null!;

        public static Dim operator +(Dim a, Dim b) => new(a.Value + b.Value);
        public static Dim operator -(Dim a, Dim b) => new(a.Value - b.Value);
        public static Dim operator *(Dim a, Dim b)
        {
            double value = a.Value * b.Value;
            var binaryExpression = Expression.Multiply(a.Formula, b.Formula);

            if (a.GetType() == b.GetType())
            {
                binaryExpression = Expression.Power(a.Formula, Expression.Constant(2.0));
            }

            Dim dim = new(value)
            {
                Formula = binaryExpression
            };
            return dim;
        }

        public static Dim operator /(Dim a, Dim b)
        {
            double value = a.Value / b.Value;
            var binaryExpression = Expression.Divide(a.Formula, b.Formula);
            if (a.GetType() == b.GetType())
            {
                binaryExpression = null;
            }

            Dim dim = new(value)
            {
                Formula = binaryExpression
            };
            return dim;
        }

        public override string ToString() => $"{Value} units";
    }
}
