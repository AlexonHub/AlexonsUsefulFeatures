using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresMass;
using Alexon.Quantities.MeasuresMass.SI;
using Alexon.Quantities.MeasuresTime;
using Alexon.Quantities.MeasuresTime.SI;
using System.Linq.Expressions;

namespace Alexon.Quantities.Base
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

        public static DerivedQuantity CreateNewtonForce(decimal value)
        {
            var mass = new Mass().Set<Kilogram>(value);
            var length = new Length().Set<Meter>(1); 
            var time = new Time().Set<Second>(1);
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

        public static DerivedQuantity CreateAcceleration<L, T>(decimal value)
            where L : Length, new ()
            where T : Time, new ()
        {
            var length = new Length().Set<L>(value);
            var time = new Time().Set<T>(1);
            return (DerivedQuantity)Acceleration().Compile()(length, time, time);
        }

        public static DerivedQuantity CreateAcceleration(DerivedQuantity speed, Time time)
        {
            return (DerivedQuantity)Acceleration().Compile()((Length)speed.Left, (Time)speed.Right, time);
        }
    }
}
