using Alexon.Quantities;
using Alexon.Quantities.MeasuresLength.ImperialUS;
using Alexon.Quantities.MeasuresLength.SI;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class ConversionFactorTests
    {
        [Test()]
        public void GetFormulaTest()
        {
            var left = typeof(Meter);
            var right = typeof(Foot);
            var formula = ConversionFactor.GetFormula(left, right);
            formula.ToString().Should().Be("x => (x * 3.28084)");

            var invertedFormula = ConversionFactor.GetFormula(right, left);
            invertedFormula.ToString().Should().Be("x => (x / 3.28084)");

        }

        [Test()]
        public void ConvertTest()
        {
            var meter = Length<Meter>.Init(1);
            var foot = Length<Foot>.Init(3.28084);

            var footFromMeter = meter.To<Foot>();
            footFromMeter.Should().Be(foot);

            var meterFromFoot = foot.To<Meter>();
            meterFromFoot.Should().Be(meter);
        }
    }
}