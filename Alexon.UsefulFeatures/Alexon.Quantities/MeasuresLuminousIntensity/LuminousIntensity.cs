using Alexon.Quantities.Base;

namespace Alexon.Quantities.MeasuresLuminousIntensity
{
    public class LuminousIntensity: Quantity
    {
        public override string Measure { get; } = "Luminous Intensity";
        public override string Description => "Power of light source in a specific direction.";
        public override string DimensionSymbol => "J";
        public override string QuantitySymbol => "Iv";
    }
}