using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresTemperature;
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
            var celsius = new Temperature().Set<Celsius>(100);
            celsius.Write().Should().Be("T = 100 °C");
            celsius.ToKelvin().Write().Should().Be("T = 373.15 K");
            celsius.ToFahrenheit().Write().Should().Be("T = 212 °F");

            var kelvin = new Temperature().Set<Kelvin>(373.15m);
            kelvin.Write().Should().Be("T = 373.15 K");
            kelvin.ToCelsius().Write().Should().Be("T = 100 °C");
            kelvin.ToFahrenheit().Write().Should().Be("T = 212 °F");

            var fahrenheit = new Temperature().Set<Fahrenheit>(212);
            fahrenheit.Write().Should().Be("T = 212 °F");
            fahrenheit.ToKelvin().Write().Should().Be("T = 373.15 K");
            fahrenheit.ToCelsius().Write().Should().Be("T = 100 °C");

        }

    }
}