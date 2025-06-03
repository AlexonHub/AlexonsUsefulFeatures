using Alexon.Quantities.MeasuresLength.ImperialUS;
using Alexon.Quantities.MeasuresLength.SI;

namespace Alexon.Quantities.MeasuresLength
{
    public static class LengthExtensions
    {
        public static Foot ToFeet(this Meter input) => input.Set<Foot>(input.Value * 3.28084m);
        public static Foot ToFeet(this Inch input) => input.Set<Foot>(input.Value / 12m);

        public static Inch ToInches(this Meter input) => input.Set<Inch>(input.Value * 39.3701m);
        public static Inch ToInches(this Foot input) => input.Set<Inch>(input.Value * 12m);

        public static Meter ToMeters(this Foot input) => input.Set<Meter>(input.Value / 3.28084m);
        public static Meter ToMeters(this Inch input) => input.Set<Meter>(input.Value / 39.3701m);
    }
}
