namespace Alexon.Quantities.MeasuresMass
{
    public class Mass: Quantity
    {
        public override string Measure { get; } = "Mass";
        public override string Description => "Amount of matter or inertia.";
        public override string DimensionSymbol => "M";
        public override string QuantitySymbol => "m";
    }
}