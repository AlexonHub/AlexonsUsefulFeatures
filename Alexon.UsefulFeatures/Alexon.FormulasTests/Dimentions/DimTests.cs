using Alexon.Formulas.Dimentions;
using FluentAssertions;

namespace Alexon.FormulasTests.Dimentions
{
    [TestClass()]
    public class DimTests
    {
        [TestMethod()]
        public void DimTest()
        {
            var length = new L(5);
            var square = length * length;
            square.Value.Should().Be(25);
            square.Formula.ToString().Should().Be("(m ** 2)");

            var volume = square * length;
            volume.Value.Should().Be(125);
            volume.Formula.ToString().Should().Be("((m ** 2) * m)");

        }

        [TestMethod()]
        public void SpeedTest()
        {
            var length = new L(5);
            var time = new T(1);

            var speed = length / time;
            speed.Value.Should().Be(5);
            speed.Formula.ToString().Should().Be("(m / s)");

       }
    }
}