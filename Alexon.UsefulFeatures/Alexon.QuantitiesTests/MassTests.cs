using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresMass;
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
            var mass1Kg = new Mass().Set<Kilogram>(1);
            mass1Kg.Value.Should().Be(1);
            mass1Kg.Write().Should().Be("m = 1 kg");

            var kiloPounds = mass1Kg.ToPound();
            kiloPounds.Should().BeOfType<Pound>();
            kiloPounds.Value.Should().Be(2.20462m);
            kiloPounds.Write().Should().Be("m = 2,20462 lb");

            var pound = new Pound { Value = 2.20462m };
            var mass1kg = pound.ToKilogram();
            mass1kg.Value.Should().Be(1);
            mass1kg.Write().Should().Be("m = 1 kg");
            mass1kg.Should().BeOfType<Kilogram>();

            var gram = mass1Kg.ToGram();
            gram.Should().BeOfType<Gram>();
            gram.Value.Should().Be(1000);
            gram.Write().Should().Be("m = 1000 g");

            var massFromGram = gram.ToKilogram();
            massFromGram.Value.Should().Be(1);
            massFromGram.Write().Should().Be("m = 1 kg");
            massFromGram.Should().BeOfType<Kilogram>();

        }
    }
}