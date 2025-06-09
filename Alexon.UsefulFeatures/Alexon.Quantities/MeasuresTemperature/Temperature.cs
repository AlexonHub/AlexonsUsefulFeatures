namespace Alexon.Quantities.MeasuresTemperature
{
    public class Temperature : Quantity
    {
        public override string Measure { get; } = "Thermodynamic Temperature";
        public override string Description => "Average kinetic energy of particles.";
        public override string DimensionSymbol => "Θ";
        public override string QuantitySymbol => "T";

        public new T To<T>() where T : Temperature, new()
        {
            decimal value = Value;

            (Type from, Type to) = (GetType(), typeof(T));
            var key = $"{from.Name}To{to.Name}";
            switch (key)
            {
                case "CelsiusToKelvin":
                    value += 273.15m;
                    break;
                case "KelvinToCelsius":
                    value -= 273.15m;
                    break;
                case "FahrenheitToCelsius":
                    value = (value - 32) * 5 / 9;
                    break;
                case "CelsiusToFahrenheit":
                    value = (value * 9 / 5) + 32;
                    break;
                case "KelvinToFahrenheit":
                    value = (value - 273.15m) * 9 / 5 + 32;
                    break;
                case "FahrenheitToKelvin":
                    value = (value - 32) * 5 / 9 + 273.15m;
                    break;
            }

            return new T()
            {
                NaturalDegree = NaturalDegree,
                Prefix = Prefix,
                Value = value
            };

        }

    }
}