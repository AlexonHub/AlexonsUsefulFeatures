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
            day.Value.Should().Be(1);
            day.ToString().Should().Be("t = 1 d");

            var hour = day.To<Hour>();
            hour.Value.Should().Be(24);
            hour.ToString().Should().Be("t = 24 h");

            var minute = hour.To<Minute>();
            minute.Value.Should().Be(1440);
            minute.ToString().Should().Be("t = 1440 min");

            var second = minute.To<Second>();
            second.Value.Should().Be(86400);
            second.ToString().Should().Be("t = 86400 s");
        }

        [Test()]
        public void HourTest()
        { 
            var hour = Time<Hour>.Init(12);
            hour.Value.Should().Be(12);
            hour.ToString().Should().Be("t = 12 h");

            var minutes = hour.To<Minute>();
            minutes.Value.Should().Be(720);
            minutes.ToString().Should().Be("t = 720 min");

            var seconds = hour.To<Second>();
            seconds.Value.Should().Be(43200);
            seconds.ToString().Should().Be("t = 43200 s");

            var day = hour.To<Day>();
            day.Value.Should().Be(0.5m);
            day.ToString().Should().Be("t = 0.5 d");

        }

        [Test()]
        public void MiniteTest()
        {
            var minutes = Time<Minute>.Init(720);
            minutes.Value.Should().Be(720);
            minutes.ToString().Should().Be("t = 720 min");

            var seconds = minutes.To<Second>();
            seconds.Value.Should().Be(43200);
            seconds.ToString().Should().Be("t = 43200 s");

            var hours = seconds.To<Hour>();
            hours.Value.Should().Be(12);
            hours.ToString().Should().Be("t = 12 h");

            var day = minutes.To<Day>();
            day.Value.Should().Be(0.5m);
            day.ToString().Should().Be("t = 0.5 d");

        }

        [Test()]
        public void SecondTest()
        {
            var seconds = Time<Second>.Init(86400);
            seconds.Value.Should().Be(86400);
            seconds.ToString().Should().Be("t = 86400 s");

            var minutes = seconds.To<Minute>();
            minutes.Value.Should().Be(1440);
            minutes.ToString().Should().Be("t = 1440 min");

            var hours = seconds.To<Hour>();
            hours.Value.Should().Be(24);
            hours.ToString().Should().Be("t = 24 h");

            var day = seconds.To<Day>();
            day.Value.Should().Be(1);
            day.ToString().Should().Be("t = 1 d");

        }
    }
}