using Alexon.Quantities.MeasuresLength.ImperialUS;
using Alexon.Quantities.MeasuresLength.SI;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.Quantities.Tests
{
    [TestFixture()]
    public class ConversionFactorTests
    {
        [Test()]
        public void ConvertTest()
        {
            var meter = Length<Meter>.Init(1);
            var foot = Length<Foot>.Init(3.28084m);

            var footFromMeter = meter.To<Foot>();
            footFromMeter.Should().Be(foot);

            var meterFromFoot = foot.To<Meter>();
            meterFromFoot.Should().Be(meter);
        }
    }
}