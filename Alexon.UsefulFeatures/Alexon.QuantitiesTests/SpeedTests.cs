using Alexon.Quantities.Base;
using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresTime;
using Alexon.Quantities.MeasuresTime.SI;
using Alexon.Quantities.MeasuresTime.SI.Derived;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class SpeedTests
    {
        [Test()]
        public void SpeedKiloNeterPerHourTest()
        {
            var length = new Length().Set<Kilo, Meter>(5);
            var hour = new Time().Set<Hour>(1);
            var speedKmH = Speed.CreateSpeed(length, hour);

            speedKmH.UnitSymbol.Should().Be("(m/h)");
            speedKmH.Value.Should().Be(5000);
            speedKmH.QuantitySymbol.Should().Be("v");
            speedKmH.Description.Should().Be("Length per Time");
            speedKmH.Measure.Should().Be("Speed");
            speedKmH.Write().Should().Be("v = 5 k(m/h)");

            var sdeedFromDivide = length / hour;
            (sdeedFromDivide == speedKmH).Should().BeTrue();
        }

        [Test()]
        public void CreateSpeedTest()
        {
            var length = new Length().Set<Meter>(5);
            var time = new Time().Set<Second>(1);

            var speed = Speed.CreateSpeed(length, time);

            speed.UnitSymbol.Should().Be("(m/s)");
            speed.Value.Should().Be(5);
            speed.QuantitySymbol.Should().Be("v");
            speed.Description.Should().Be("Length per Time");
            speed.Measure.Should().Be("Speed");
            speed.Write().Should().Be("v = 5 (m/s)");

            var speedFromTyped = Speed.CreateSpeed<Meter, Second>(5);
            (speedFromTyped == speed).Should().BeTrue();

            var fromDivide = length / time;
            (fromDivide == speed).Should().BeTrue();
        }

        [Test()]
        public void SpeedConversionTest()
        {
            var speedMS = Speed.CreateSpeed<Meter, Second>(5);

            var lengthKm = (Length)speedMS.Left.Set<Kilo, Meter>(speedMS.Value);
            var speedH = speedMS.Right.As<Second>().ToHour();

            var speedKMH = Speed.CreateSpeed(lengthKm, speedH);

            //speedKMH.UnitSymbol.Should().Be("(k(m/h))");
            //speedKMH.Value.Should().Be(18); // 5 m/s = 18 km/h
            //speedKMH.QuantitySymbol.Should().Be("v");
            //speedKMH.Description.Should().Be("Length per Time");
            //speedKMH.Measure.Should().Be("Speed");
            //speedKMH.Write().Should().Be("v = 18 k(m/h)");

        }
    }
}