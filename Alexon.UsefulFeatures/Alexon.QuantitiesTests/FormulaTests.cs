using Alexon.Quantities.Base;
using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresMass;
using Alexon.Quantities.MeasuresMass.SI;
using Alexon.Quantities.MeasuresTime;
using Alexon.Quantities.MeasuresTime.SI;
using Alexon.Quantities.MeasuresTime.SI.Derived;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class FormulaTests
    {
        [Test()]
        public void CreateAccelerationTest()
        {
            Meter length = new Length().Set<Meter>(5);
            Second time = new Time().Set<Second>(1);

            var speed = Speed.CreateSpeed(length, time);
            var accelerationFromSpeed = Formula.CreateAcceleration(speed, time);

            var acceleration = Formula.CreateAcceleration<Meter,Second>(5);

            acceleration.UnitSymbol.Should().Be("((m/s)/s)");
            acceleration.Value.Should().Be(5);
            acceleration.QuantitySymbol.Should().Be("a");
            acceleration.Description.Should().Be("Speed per Time");
            acceleration.Measure.Should().Be("Acceleration");
            acceleration.Write().Should().Be("a = 5 ((m/s)/s)");

            (accelerationFromSpeed == acceleration).Should().BeTrue();
            
            var fromDivide = speed / time;
            (fromDivide == acceleration).Should().BeTrue();
        }

        [Test()]
        public void ForceTest()
        {
            var mass = new Mass().Set<Kilogram>(1);
            var acceleration = Formula.CreateAcceleration<Meter, Second>(5);

            var formula = Formula.Force();
            formula.ToString().Should().Be("(m, l, t, t) => (m * ((l / t) / t))");
            
            var force = Formula.CreateNewtonForce(5);
            force.UnitSymbol.Should().Be("N");
            force.Value.Should().Be(5);
            force.QuantitySymbol.Should().Be("f");
            force.Description.Should().Be("Mass times Acceleration");
            force.Measure.Should().Be("Force");
            force.Write().Should().Be("f = 5 N");

            var forceFromAcceleration = Formula.CreateForce(mass, acceleration);
            (forceFromAcceleration == force).Should().BeTrue();

            var fromDivide = mass * acceleration;
            (fromDivide == force).Should().BeTrue();

        }

    }
}