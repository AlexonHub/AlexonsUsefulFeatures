using Alexon.Quantities;
using Alexon.Quantities.MeasuresTime.SI;
using Alexon.Quantities.MeasuresTime.SI.Derived;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class TimeTests
    {
        [Test()]
        public void DayTest()
        {
            var day = Time<Day>.Init(1);
            day.QuantityValue.Should().Be(1);
            day.ToString().Should().Be("t = 1 d");

            var hour = day.To<Hour>();
            hour.QuantityValue.Should().Be(24);
            hour.ToString().Should().Be("t = 24 h");

            var minute = hour.To<Minute>();
            minute.QuantityValue.Should().Be(1440);
            minute.ToString().Should().Be("t = 1440 min");

            var second = minute.To<Second>();
            second.QuantityValue.Should().Be(86400);
            second.ToString().Should().Be("t = 86400 s");
        }

        [Test()]
        public void HourTest()
        { 
            var hour = Time<Hour>.Init(12);
            hour.QuantityValue.Should().Be(12);
            hour.ToString().Should().Be("t = 12 h");

            var minutes = hour.To<Minute>();
            minutes.QuantityValue.Should().Be(720);
            minutes.ToString().Should().Be("t = 720 min");

            var seconds = hour.To<Second>();
            seconds.QuantityValue.Should().Be(43200);
            seconds.ToString().Should().Be("t = 43200 s");

            var day = hour.To<Day>();
            day.QuantityValue.Should().Be(0.5);
            day.ToString().Should().Be("t = 0.5 d");

        }

        [Test()]
        public void MiniteTest()
        {
            var minutes = Time<Minute>.Init(720);
            minutes.QuantityValue.Should().Be(720);
            minutes.ToString().Should().Be("t = 720 min");

            var seconds = minutes.To<Second>();
            seconds.QuantityValue.Should().Be(43200);
            seconds.ToString().Should().Be("t = 43200 s");

            var hours = seconds.To<Hour>();
            hours.QuantityValue.Should().Be(12);
            hours.ToString().Should().Be("t = 12 h");

            var day = minutes.To<Day>();
            day.QuantityValue.Should().Be(0.5);
            day.ToString().Should().Be("t = 0.5 d");

        }

        [Test()]
        public void SecondTest()
        {
            var seconds = Time<Second>.Init(86400);
            seconds.QuantityValue.Should().Be(86400);
            seconds.ToString().Should().Be("t = 86400 s");

            var minutes = seconds.To<Minute>();
            minutes.QuantityValue.Should().Be(1440);
            minutes.ToString().Should().Be("t = 1440 min");

            var hours = seconds.To<Hour>();
            hours.QuantityValue.Should().Be(24);
            hours.ToString().Should().Be("t = 24 h");

            var day = seconds.To<Day>();
            day.QuantityValue.Should().Be(1);
            day.ToString().Should().Be("t = 1 d");

        }

        [Test()]
        public void TwoWayTest()
        { 
            var second3600 = Time<Second>.Init(3600);
            var hours = second3600.To<Hour>();
            hours.QuantityValue.Should().Be(1);
            hours.ToString().Should().Be("t = 1 h");
            var secondFromHour = hours.To<Second>();
            secondFromHour.QuantityValue.Should().Be(3600);
            secondFromHour.ToString().Should().Be("t = 3600 s");

        }
    }
}