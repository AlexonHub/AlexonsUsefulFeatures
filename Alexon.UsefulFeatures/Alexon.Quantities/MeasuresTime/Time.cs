using Alexon.Quantities.Base;

namespace Alexon.Quantities.MeasuresTime
{
    public class Time : Quantity
    {
        public override string Measure { get; } = "Time";
        public override string Description => "Duration of an event.";
        public override string DimensionSymbol => "T";
        public override string QuantitySymbol => "t";
    }
}