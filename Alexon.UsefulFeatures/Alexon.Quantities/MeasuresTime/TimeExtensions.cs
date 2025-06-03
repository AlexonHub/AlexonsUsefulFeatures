using Alexon.Quantities.Base;
using Alexon.Quantities.MeasuresTime.SI;
using Alexon.Quantities.MeasuresTime.SI.Derived;

namespace Alexon.Quantities.MeasuresTime
{
    public static class TimeExtensions
    {
        public static Minute ToMinute(this Second input) { return input.Set<Minute>(input.Value / 60); }
        public static Minute ToMinute(this Hour input) { return input.Set<Minute>(input.Value * 60); }
        public static Minute ToMinute(this Day input) { return input.Set<Minute>(input.Value * 1440); }

        public static Second ToSecond(this Minute input) { return input.Set<Second>(input.Value * 60); }
        public static Second ToSecond(this Hour input) { return input.Set<Second>(input.Value * 3600); }
        public static Second ToSecond(this Day input) { return input.Set<Second>(input.Value * 86400); }

        public static Hour ToHour(this Second input) { return input.Set<Hour>(input.Value / 3600); }
        public static Hour ToHour(this Minute input) { return input.Set<Hour>(input.Value / 60); }
        public static Hour ToHour(this Day input) { return input.Set<Hour>(input.Value * 24); }

        public static Day ToDay(this Second input) { return input.Set<Day>(input.Value / 86400); }
        public static Day ToDay(this Minute input) { return input.Set<Day>(input.Value / 1440); }
        public static Day ToDay(this Hour input) { return input.Set<Day>(input.Value / 24); }

    }

}
