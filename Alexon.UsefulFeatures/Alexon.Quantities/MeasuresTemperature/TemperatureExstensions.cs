using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresTemperature.ImperialUS;
using Alexon.Quantities.MeasuresTemperature.SI;
using Alexon.Quantities.MeasuresTemperature.SI.Derived;

namespace Alexon.Quantities.MeasuresTemperature
{
    public static class TemperatureExstensions
    {
        public static Kelvin ToKelvin(this Celsius input) => input.Set<Kelvin>(input.Value + 273.15m);
        public static Kelvin ToKelvin(this Fahrenheit input) => input.Set<Kelvin>((input.Value - 32) * 5 / 9 + 273.15m);

        public static Celsius ToCelsius(this Kelvin input) => input.Set<Celsius>(input.Value - 273.15m);
        public static Celsius ToCelsius(this Fahrenheit input) => input.Set<Celsius>((input.Value - 32) * 5 / 9);

        public static Fahrenheit ToFahrenheit(this Kelvin input) => input.Set<Fahrenheit>((input.Value - 273.15m) * 9 / 5 + 32);
        public static Fahrenheit ToFahrenheit(this Celsius input) => input.Set<Fahrenheit>(input.Value * 9 / 5 + 32);

    }
}
