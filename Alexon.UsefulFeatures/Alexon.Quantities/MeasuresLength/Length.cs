using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresTime;

namespace Alexon.Quantities.MeasuresLength
{
    public class Length : Quantity
    {
        public override string Measure { get; } = "Length";
        public override string Description => "One-dimensional extent.";
        public override string DimensionSymbol => "L";
        public override string QuantitySymbol => "l";

        public static Speed operator /(Length left, Time right)
        {
            if (right.QuantityValue == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return (Speed)left.OperationWithDifferentTypes<Speed>(Operation.Divide, right);
        }

    }
}