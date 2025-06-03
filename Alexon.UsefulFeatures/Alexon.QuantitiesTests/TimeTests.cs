using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresTime;
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
            var day = new Time().Set<Day>(1);
            day.Value.Should().Be(1);
            day.Write().Should().Be("t = 1 d");

            var hour = day.ToHour();
            hour.Value.Should().Be(24);
            hour.Write().Should().Be("t = 24 h");

            var minute = hour.ToMinute();
            minute.Value.Should().Be(1440);
            minute.Write().Should().Be("t = 1440 min");

            var second = minute.ToSecond();
            second.Value.Should().Be(86400);
            second.Write().Should().Be("t = 86400 s");
        }

        [Test()]
        public void HourTest()
        { 
            var hour = new Time().Set<Hour>(12);
            hour.Value.Should().Be(12);
            hour.Write().Should().Be("t = 12 h");

            var minutes = hour.ToMinute();
            minutes.Value.Should().Be(720);
            minutes.Write().Should().Be("t = 720 min");

            var seconds = hour.ToSecond();
            seconds.Value.Should().Be(43200);
            seconds.Write().Should().Be("t = 43200 s");

            var day = hour.ToDay();
            day.Value.Should().Be(0.5m);
            day.Write().Should().Be("t = 0.5 d");

        }

        [Test()]
        public void MiniteTest()
        {
            var minutes = new Time().Set<Minute>(720);
            minutes.Value.Should().Be(720);
            minutes.Write().Should().Be("t = 720 min");

            var seconds = minutes.ToSecond();
            seconds.Value.Should().Be(43200);
            seconds.Write().Should().Be("t = 43200 s");

            var hours = seconds.ToHour();
            hours.Value.Should().Be(12);
            hours.Write().Should().Be("t = 12 h");

            var day = minutes.ToDay();
            day.Value.Should().Be(0.5m);
            day.Write().Should().Be("t = 0.5 d");

        }

        [Test()]
        public void SecondTest()
        {
            var seconds = new Time().Set<Second>(86400);
            seconds.Value.Should().Be(86400);
            seconds.Write().Should().Be("t = 86400 s");

            var minutes = seconds.ToMinute();
            minutes.Value.Should().Be(1440);
            minutes.Write().Should().Be("t = 1440 min");

            var hours = seconds.ToHour();
            hours.Value.Should().Be(24);
            hours.Write().Should().Be("t = 24 h");

            var day = seconds.ToDay();
            day.Value.Should().Be(1);
            day.Write().Should().Be("t = 1 d");

        }
    }
}