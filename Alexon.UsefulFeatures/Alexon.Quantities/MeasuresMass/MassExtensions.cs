using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresMass.CGS;
using Alexon.Quantities.MeasuresMass.ImperialUS;
using Alexon.Quantities.MeasuresMass.SI;

namespace Alexon.Quantities.MeasuresMass
{
    public static class MassExtensions
    {
        public static Pound ToPound(this Kilogram input) => input.Set<Pound>(input.Value * 2.20462m); // Conversion factor from kg to lb
        public static Kilogram ToKilogram(this Pound input) => input.Set<Kilogram>((input.Value) / 2.20462m); // Conversion factor from lb to kg
        public static Gram ToGram(this Kilogram input) => input.Set<Gram>(input.Value * 1000); // Conversion factor from kg to g
        public static Kilogram ToKilogram(this Gram input) => input.Set<Kilogram>(input.Value / 1000); // Conversion factor from g to kg
    }
}
