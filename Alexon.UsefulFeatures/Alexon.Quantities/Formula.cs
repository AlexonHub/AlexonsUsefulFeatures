using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresMass;
using Alexon.Quantities.MeasuresMass.SI;
using Alexon.Quantities.MeasuresTime;
using Alexon.Quantities.MeasuresTime.SI;
using System.Linq.Expressions;

namespace Alexon.Quantities
{
    
    public static class Formula
    {
        public static Expression<Func<Mass, Length, Time, Time, Quantity>> Force()
        {
            var left = Expression.Parameter(typeof(Quantity), new Mass().QuantitySymbol);
            var accelerationFormula = Acceleration();
            var accelerationBody = accelerationFormula.Body;
            var forceBody = Expression.Multiply(left, accelerationBody);

            var lambda = Expression.Lambda<Func<Mass, Length, Time, Time, Quantity>>
                (forceBody,
                left,
                accelerationFormula.Parameters[0],
                accelerationFormula.Parameters[1],
                accelerationFormula.Parameters[2]
                );
            return lambda;
        }

        public static DerivedQuantity CreateNewtonForce(double value)
        {
            var mass = Mass<Kilogram>.Init(value);
            var length = Length<Meter>.Init(1); 
            var time = Time<Second>.Init(1);
            return (DerivedQuantity)Force().Compile()(mass, length, time, time);
        }

        public static DerivedQuantity CreateForce(Mass mass, DerivedQuantity acceleration)
        {
            var speed = (DerivedQuantity)acceleration.Left;
            return (DerivedQuantity)Force().Compile()(mass, (Length)speed.Left, (Time)speed.Right, (Time)acceleration.Right);
        }

        public static Expression<Func<Length, Time, Time, Quantity>> Acceleration()
        {
            var left = Expression.Parameter(typeof(Quantity), new Length().QuantitySymbol);
            var middle = Expression.Parameter(typeof(Quantity), new Time().QuantitySymbol);
            var right = Expression.Parameter(typeof(Quantity), new Time().QuantitySymbol);

            var speedBody = Expression.Divide(left, middle);
            var accelerationBody = Expression.Divide(speedBody, right);

            var lambda = Expression.Lambda<Func<Length, Time, Time, Quantity>>(accelerationBody, left, middle, right);
            return lambda;
        }

        public static DerivedQuantity CreateAcceleration<L, T>(double value) where L : Length, new() where T : Time, new() => (DerivedQuantity)Acceleration().Compile()(Length<L>.Init(value), Time<T>.Init(1), Time<T>.Init(1));
        public static DerivedQuantity CreateAcceleration(DerivedQuantity speed, Time time) => (DerivedQuantity)Acceleration().Compile()((Length)speed.Left, (Time)speed.Right, time);
    }
}
