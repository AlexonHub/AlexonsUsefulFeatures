using Alexon.Quantities.Base;

namespace Alexon.Quantities.MeasuresTemperature
{
    public class Temperature : Quantity
    {
        public override string Measure { get; } = "Thermodynamic Temperature";
        public override string Description => "Average kinetic energy of particles.";
        public override string DimensionSymbol => "Θ";
        public override string QuantitySymbol => "T";
    }
}