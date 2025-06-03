namespace Alexon.Quantities.MeasuresElectricCurrent
{
    public class ElectricCurrent: Quantity
    {
        public override string Measure { get; } = "Electric Current";
        public override string Description => "Rate of flow of electric charge.";
        public override string DimensionSymbol => "I";
        public override string QuantitySymbol => "I";
    }
}