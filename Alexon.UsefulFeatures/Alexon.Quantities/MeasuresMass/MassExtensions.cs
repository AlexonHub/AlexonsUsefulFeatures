using Alexon.Quantities.MeasuresMass.ImperialUS;
using Alexon.Quantities.MeasuresMass.SI;

namespace Alexon.Quantities.MeasuresMass
{
    public static class MassExtensions
    {
        public static Pound ToPound(this Kilogram input) => input.Set<Pound>(input.Value * 2.20462m); // Conversion factor from kg to lb
        public static Kilogram ToKilogram(this Pound input) => input.Set<Kilogram>((input.Value) / 2.20462m); // Conversion factor from lb to kg

    }
}
