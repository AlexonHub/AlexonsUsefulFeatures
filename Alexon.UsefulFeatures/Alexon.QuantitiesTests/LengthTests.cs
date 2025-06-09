using Alexon.Quantities;
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
            var meters = Length<Meter>.Init(100m);
            meters.ToString().Should().Be("l = 100 m");
            meters.To<Foot>().ToString().Should().Be("l = 328.084 ft");
            meters.To<Inch>().ToString().Should().Be("l = 3937.01 in");

            var feet = Length<Foot>.Init(328.084m);
            feet.ToString().Should().Be("l = 328.084 ft");
            feet.To<Meter>().ToString().Should().Be("l = 100 m");
            feet.To<Inch>().ToString().Should().Be("l = 3937.008 in");

            var inches = Length<Inch>.Init(3937.01m);
            inches.ToString().Should().Be("l = 3937.01 in");
            var meters100 = inches.To<Meter>();
            meters100.ToString().Should().Be("l = 100 m");
            Length<Inch>.Init(1200).To<Foot>().ToString().Should().Be("l = 100 ft");

        }

    }
}