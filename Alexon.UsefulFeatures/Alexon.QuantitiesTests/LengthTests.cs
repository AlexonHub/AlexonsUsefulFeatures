using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.ImperialUS;
using Alexon.Quantities.MeasuresLength.SI;
using FluentAssertions;
using NUnit.Framework;
namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class LengthTests
    {
        [Test()]
        public void LengthTest()
        {
            var meters = new Length().Set<Meter>(100m);
            meters.ToString().Should().Be("l = 100 m");
            meters.ToFeet().ToString().Should().Be("l = 328.084 ft");
            meters.ToInches().ToString().Should().Be("l = 3937.01 in");

            var feet = new Length().Set<Foot>(328.084m);
            feet.ToString().Should().Be("l = 328.084 ft");
            feet.ToMeters().ToString().Should().Be("l = 100 m");
            feet.ToInches().ToString().Should().Be("l = 3937.008 in");

            var inches = new Length().Set<Inch>(3937.01m);
            inches.ToString().Should().Be("l = 3937.01 in");
            var meters100 = inches.ToMeters();
            meters100.ToString().Should().Be("l = 100 m");
            inches.Set<Inch>(1200).As<Inch>().ToFeet().ToString().Should().Be("l = 100 ft");

        }

    }
}