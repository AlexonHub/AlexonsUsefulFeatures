using NUnit.Framework;
using FluentAssertions;
using Alexon.Quantities.Prefixes;

namespace Alexon.QuantitiesTests.Prefixes
{
    [TestFixture()]
    public class PrefixTests
    {
        [Test()]
        public void FormulaTest()
        {
            var gram = 1.0;
            var kilo = new Kilo();
            kilo.Formula?.ToString().Should().Be("x => (x / 1000)");
            var kilogram = kilo.Formula?.Calculate(gram);
            kilogram.Should().Be(0.001); // 1 gram = 0.001 kilogram

            var milli = new Milli();
            milli.Formula?.ToString().Should().Be("x => (x / 0.001)");
            var milligram = milli.Formula?.Calculate(gram);
            milligram.Should().Be(1000); // 1 gram = 1000 milligrams

        }

    }
}