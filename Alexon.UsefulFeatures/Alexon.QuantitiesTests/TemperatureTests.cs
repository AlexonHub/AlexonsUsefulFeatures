using Alexon.Quantities;
using Alexon.Quantities.MeasuresTemperature.ImperialUS;
using Alexon.Quantities.MeasuresTemperature.SI;
using Alexon.Quantities.MeasuresTemperature.SI.Derived;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class TemperatureTests
    {
        [Test()]
        public void TemperatureTest()
        {
            var celsius = Temperature<Celsius>.Init(100);
            celsius.ToString().Should().Be("T = 100 °C");
            celsius.To<Kelvin>().ToString().Should().Be("T = 373.15 K");
            celsius.To<Fahrenheit>().ToString().Should().Be("T = 212 °F");

            var kelvin = Temperature<Kelvin>.Init(373.15m);
            kelvin.ToString().Should().Be("T = 373.15 K");
            kelvin.To<Celsius>().ToString().Should().Be("T = 100 °C");
            kelvin.To<Fahrenheit>().ToString().Should().Be("T = 212 °F");

            var fahrenheit = Temperature<Fahrenheit>.Init(212);
            fahrenheit.ToString().Should().Be("T = 212 °F");
            fahrenheit.To<Kelvin>().ToString().Should().Be("T = 373.15 K");
            fahrenheit.To<Celsius>().ToString().Should().Be("T = 100 °C");

        }

    }
}