using Alexon.Quantities;
using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresTime.SI;
using Alexon.Quantities.MeasuresTime.SI.Derived;
using Alexon.Quantities.Prefixes;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.Quantities.Derived.Tests
{
    [TestFixture()]
    public class SpeedTests
    {
        [Test()]
        public void SpeedKiloNeterPerHourTest()
        {
            var length = Length<Kilo, Meter>.Init(5);
            var hour = Time<Hour>.Init(1);

            var speedKmH = Speed.Init(length, hour);
            speedKmH.UnitSymbol.Should().Be("m/h");
            speedKmH.Value.Should().Be(5000);
            speedKmH.MetricValue.Should().Be(5);
            speedKmH.MetricUnitSymbol.Should().Be("km/h");
            speedKmH.Description.Should().Be("Length per Time");
            speedKmH.Measure.Should().Be("Speed");
            speedKmH.ToString().Should().Be("v = 5 km/h");

            var sdeedFromDivide = length / hour;
            sdeedFromDivide.Should().Be(speedKmH);
        }

        [Test()]
        public void CreateSpeedTest()
        {
            var length = Length<Meter>.Init(5);
            var time = Time<Second>.Init(1);

            var speed = Speed.Init(length, time);
            speed.UnitSymbol.Should().Be("m/s");
            speed.Value.Should().Be(5);
            speed.QuantitySymbol.Should().Be("v");
            speed.Description.Should().Be("Length per Time");
            speed.Measure.Should().Be("Speed");
            speed.ToString().Should().Be("v = 5 m/s");

            var speedFromTyped = Speed.Init<Meter, Second>(5);
            speedFromTyped.Should().Be(speed);

            var fromDivide = length / time;
            fromDivide.Should().Be(speed);
        }

        [Test()]
        public void SpeedConversionTest()
        {
            var speedMS = Speed.Init<Meter, Second>(1);
            var speedKMS = (Speed)speedMS.ToMetric<Kilo>();
            speedKMS.Left.Prefix.Should().BeOfType<Kilo>();
            speedKMS.UnitSymbol.Should().Be("m/s");
            speedKMS.MetricUnitSymbol.Should().Be("km/s");
            speedKMS.MetricValue.Should().Be(0.001m);
            speedKMS.Value.Should().Be(1);
            speedKMS.ToString().Should().Be("v = 0.001 km/s");

            var speedKMH = speedKMS.To<Meter, Hour>();
            speedKMH.MetricUnitSymbol.Should().Be("km/h");
            speedKMH.MetricValue.Should().Be(3.6m);
            speedKMH.UnitSymbol.Should().Be("m/h");
            speedKMH.Value.Should().Be(3600);
            speedKMH.ToString().Should().Be("v = 3.6 km/h");

            var speedMH = speedMS.To<Meter, Hour>();
            speedMH.MetricUnitSymbol.Should().Be("m/h");
            speedMH.MetricValue.Should().Be(3600m);
            speedMH.UnitSymbol.Should().Be("m/h");
            speedMH.Value.Should().Be(3600);
            speedMH.ToString().Should().Be("v = 3600 m/h");

        }

        [Test()]
        public void ToTest()
        {
            var length = Length<Kilo, Meter>.Init(5);//
            var time = Time<Second>.Init(1);
            var speed = Speed.Init(length, time);

            var speedKMH = speed.To<Meter, Hour>();
            speedKMH.Value.Should().Be(18000000);
            speedKMH.UnitSymbol.Should().Be("m/h");
            speedKMH.MetricUnitSymbol.Should().Be("km/h");
            speedKMH.MetricValue.Should().Be(18000);
            speedKMH.ToString().Should().Be("v = 18000 km/h");


        }
    }
}