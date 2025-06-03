using Alexon.Quantities;
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
            meters.Write().Should().Be("l = 100 m");
            meters.ToFeet().Write().Should().Be("l = 328,084 ft");
            meters.ToInches().Write().Should().Be("l = 3937,01 in");

            var feet = new Length().Set<Foot>(328.084m);
            feet.Write().Should().Be("l = 328,084 ft");
            feet.ToMeters().Write().Should().Be("l = 100 m");
            feet.ToInches().Write().Should().Be("l = 3937,008 in");

            var inches = new Length().Set<Inch>(3937.01m);
            inches.Write().Should().Be("l = 3937,01 in");
            var meters100 = inches.ToMeters();
            meters100.Write().Should().Be("l = 100 m");
            inches.Set<Inch>(1200).As<Inch>().ToFeet().Write().Should().Be("l = 100 ft");

        }

    }
}