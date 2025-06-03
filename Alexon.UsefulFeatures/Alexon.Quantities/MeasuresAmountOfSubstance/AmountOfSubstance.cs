using Alexon.Quantities.Base;

namespace Alexon.Quantities.MeasuresAmountOfSubstance
{
    public class AmountOfSubstance: Quantity
    {
        public override string Measure { get; } = "Amount of Substance";
        public override string Description => "Number of elementary entities.";
        public override string DimensionSymbol => "N";
        public override string QuantitySymbol => "n";

    }
}