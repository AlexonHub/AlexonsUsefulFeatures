using Alexon.Formulas;
using System.Linq.Expressions;

namespace Alexon.Quantities
{
    public static class ConversionFactor
    {
        public static readonly Dictionary<string, double> conversionFactors = new()
        {
            //Length 
            { "MeterToFoot", 3.28084 },
            { "FootToInch", 12 },
            { "MeterToInch", 39.3701 },
            { "MileToMeter", 1609.34 },
            //Mass
            { "KilogramToPound", 2.20462 },
            { "KilogramToGram", 1000 },
            { "PoundToGram", 453.592 },
            //Time
            { "MinuteToSecond", 60.0 },
            { "HourToSecond", 3600.0 },
            { "DayToSecond", 86400.0 },
            { "HourToMinute", 60.0 },
            { "DayToMinute", 1440.0 },
            { "DayToHour", 24.0 }

        };

        public static double GetConversionFactor(Type from, Type to)
        {
            return conversionFactors.TryGetValue($"{from.Name}To{to.Name}", out var factor) ? factor : 1.0;
        }

        public static SimpleExpression? GetFormula(Type from, Type to)
        {
            var factor = (double)GetConversionFactor(from, to);
            if (factor != 1)
            {
                return new SimpleExpression()
                {
                    Left = Expression.Parameter(typeof(double), "x"),
                    Right = Expression.Constant(factor, typeof(double)),
                    NodeType = ExpressionType.Multiply
                };
            }

            factor = (double)GetConversionFactor(to, from);
            if (factor != 1)
            {
                return new SimpleExpression()
                {
                    Left = Expression.Parameter(typeof(double), "x"),
                    Right = Expression.Constant(factor, typeof(double)),
                    NodeType = ExpressionType.Divide
                };
            }

            return null;
        }
    }
}
