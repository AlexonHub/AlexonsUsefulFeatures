using Alexon.Quantities.Base;
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
        public override string UnitSymbol => $"({Left.UnitSymbol}/{Right.UnitSymbol})"; 
        
        public static Expression<Func<Length, Time, Speed>> Formula()
        {
            var left = Expression.Parameter(typeof(Length), new Length().QuantitySymbol);
            var right = Expression.Parameter(typeof(Time), new Time().QuantitySymbol);

            var body = Expression.Divide(left, right);
            var lambda = Expression.Lambda<Func<Length, Time, Speed>>(body, left, right);
            return lambda;
        }

        public static Speed CreateSpeed<L,T>(decimal value) where L : Length, new() where T : Time, new() => Formula().Compile()(new Length().Set<L>(value), new Time().Set<T>(1));
        public static Speed CreateSpeed(Length length, Time time) => Formula().Compile()(length, time);

    }
}
