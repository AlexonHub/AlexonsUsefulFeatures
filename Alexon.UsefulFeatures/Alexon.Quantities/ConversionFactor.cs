namespace Alexon.Quantities
{
    public static class ConversionFactor
    {
        public static readonly Dictionary<string, decimal> conversionFactors = new()
        {
            //Length 
            { "MeterToFoot", 3.28084m },
            { "FootToInch", 12m },
            { "MeterToInch", 39.3701m },
            //Mass
            { "KilogramToPound", 2.20462m },
            { "KilogramToGram", 1000m },
            { "PoundToGram", 453.592m },
            //Time
            { "MinuteToSecond", 60m },
            { "HourToSecond", 3600m },
            { "DayToSecond", 86400m },
            { "HourToMinute", 60m },
            { "DayToMinute", 1440m },
            { "DayToHour", 24m }

        };

        public static decimal GetConversionFactor(Type from, Type to)
        {
            return conversionFactors.TryGetValue($"{from.Name}To{to.Name}", out var factor) ? factor : 1m;
        }

    }
}
