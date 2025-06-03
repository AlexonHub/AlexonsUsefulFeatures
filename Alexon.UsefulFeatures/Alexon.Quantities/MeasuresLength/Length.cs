using Alexon.Quantities.Base;
using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresTime;

namespace Alexon.Quantities.MeasuresLength
{
    public class Length: Quantity
    {
        public override string Measure { get; } = "Length";
        public override string Description => "One-dimensional extent.";
        public override string DimensionSymbol => "L";
        public override string QuantitySymbol => "l";

        public static Speed operator /(Length left, Time right)
        {
            if (right.Value == 0) throw new DivideByZeroException("Cannot divide by zero.");

            var naturalDegree = left.NaturalDegree - right.NaturalDegree;
            if (naturalDegree == 0) { naturalDegree = 1; }

            return new Speed
            {
                Left = left.ShallowCopy(),
                Right = right.ShallowCopy(),
                Value = left.Value / right.Value,
                Prefix = left.Prefix,
                UnitSymbol = $"{left.UnitSymbol}/{right.UnitSymbol}",
                NaturalDegree = naturalDegree,
                Operator = "per",
            };
        }

    }
}