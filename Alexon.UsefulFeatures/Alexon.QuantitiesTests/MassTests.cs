using Alexon.Quantities;
using Alexon.Quantities.MeasuresMass.CGS;
using Alexon.Quantities.MeasuresMass.ImperialUS;
using Alexon.Quantities.MeasuresMass.SI;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class MassTests
    {
        [Test()]
        public void MassTest()
        {
            var mass1Kg = Mass<Kilogram>.Init(1);
            mass1Kg.Value.Should().Be(1);
            mass1Kg.ToString().Should().Be("m = 1 kg");

            var kiloPounds = mass1Kg.To<Pound>();
            kiloPounds.Should().BeOfType<Pound>();
            kiloPounds.Value.Should().Be(2.20462m);
            kiloPounds.ToString().Should().Be("m = 2.20462 lb");

            var pound = new Pound { Value = 2.20462m };
            var mass1kg = pound.To<Kilogram>();
            mass1kg.Value.Should().Be(1);
            mass1kg.ToString().Should().Be("m = 1 kg");
            mass1kg.Should().BeOfType<Kilogram>();

            var gram = mass1Kg.To<Gram>();
            gram.Should().BeOfType<Gram>();
            gram.Value.Should().Be(1000);
            gram.ToString().Should().Be("m = 1000 g");

            var massFromGram = gram.To<Kilogram>();
            massFromGram.Value.Should().Be(1);
            massFromGram.ToString().Should().Be("m = 1 kg");
            massFromGram.Should().BeOfType<Kilogram>();

        }
    }
}