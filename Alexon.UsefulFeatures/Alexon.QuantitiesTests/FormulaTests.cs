using Alexon.Quantities;
using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresMass.SI;
using Alexon.Quantities.MeasuresTime.SI;
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
            var length = Length<Meter>.Init(5);
            var time = Time<Second>.Init(1);
            var speed = Speed.Init(length, time);

            var acceleration = Formula.CreateAcceleration<Meter, Second>(5);
            acceleration.UnitSymbol.Should().Be("((m/s)/s)");
            acceleration.QuantityValue.Should().Be(5);
            acceleration.QuantitySymbol.Should().Be("a");
            acceleration.Description.Should().Be("Speed per Time");
            acceleration.Measure.Should().Be("Acceleration");
            acceleration.ToString().Should().Be("a = 5 ((m/s)/s)");
            
            var accelerationFromSpeed = Formula.CreateAcceleration(speed, time);
            accelerationFromSpeed.Should().Be(acceleration);

            var fromDivide = speed / time;
            fromDivide.Should().Be(acceleration);
        }

        [Test()]
        public void ForceTest()
        {
            var mass = Mass<Kilogram>.Init(1);
            var acceleration = Formula.CreateAcceleration<Meter, Second>(5);

            var formula = Formula.Force();
            formula.ToString().Should().Be("(m, l, t, t) => (m * ((l / t) / t))");

            var force = Formula.CreateNewtonForce(5);
            force.UnitSymbol.Should().Be("N");
            force.QuantityValue.Should().Be(5);
            force.QuantitySymbol.Should().Be("f");
            force.Description.Should().Be("Mass times Acceleration");
            force.Measure.Should().Be("Force");
            force.ToString().Should().Be("f = 5 N");

            var forceFromAcceleration = Formula.CreateForce(mass, acceleration);
            forceFromAcceleration.Should().Be(force);

            var fromDivide = mass * acceleration;
            fromDivide.Should().Be(force);

        }

    }
}