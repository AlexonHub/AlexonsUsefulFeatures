using Alexon.Quantities.Derived;
using Alexon.Quantities.MeasuresAmountOfSubstance;
using Alexon.Quantities.MeasuresElectricCurrent;
using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLuminousIntensity;
using Alexon.Quantities.MeasuresMass;
using Alexon.Quantities.MeasuresTemperature;
using Alexon.Quantities.MeasuresTime;
using Alexon.Quantities.Prefixes;

namespace Alexon.Quantities
{
    public abstract class Quantity<P, T> where P : Prefix, new() where T : Quantity, new()
    {
        public static T Init(double value)
        {
            P prefix = new();
            var quantity = new T()
            {
                QuantityValue = prefix.Set(value),
                Prefix = prefix,
                ConversionExpression = prefix.Formula
            };
            quantity.SetToDecimalConversionFormula();
            return quantity;
        }
    }
    public abstract class Quantity<T> where T : Quantity, new()
    {
        public static T Init(double value) => new() { QuantityValue = value };
    }

    public abstract class Length<P, T> : Quantity<P, T> where P : Prefix, new() where T : Length, new() { }
    public abstract class Length<T> : Quantity<T> where T : Length, new() { }

    public abstract class Time<P, T> : Quantity<P, T> where P : Prefix, new() where T : Time, new() { }
    public abstract class Time<T> : Quantity<T> where T : Time, new() { }

    public abstract class Mass<P, T> : Quantity<P, T> where P : Prefix, new() where T : Mass, new() { }
    public abstract class Mass<T> : Quantity<T> where T : Mass, new() { }

    public abstract class Temperature<P, T> : Quantity<P, T> where P : Prefix, new() where T : Temperature, new() { }
    public abstract class Temperature<T> : Quantity<T> where T : Temperature, new() { }

    public abstract class ElectricCurrent<P, T> : Quantity<P, T> where P : Prefix, new() where T : ElectricCurrent, new() { }
    public abstract class ElectricCurrent<T> : Quantity<T> where T : ElectricCurrent, new() { }

    public abstract class AmountOfSubstance<P, T> : Quantity<P, T> where P : Prefix, new() where T : AmountOfSubstance, new() { }
    public abstract class AmountOfSubstance<T> : Quantity<T> where T : AmountOfSubstance, new() { }

    public abstract class LuminousIntensity<P, T> : Quantity<P, T> where P : Prefix, new() where T : LuminousIntensity, new() { }
    public abstract class LuminousIntensity<T> : Quantity<T> where T : LuminousIntensity, new() { }

    //Derived
    public abstract class Speed<P, T> : Quantity<P, T> where P : Prefix, new() where T : Speed, new() { }
    public abstract class Speed<T> : Quantity<T> where T : Speed, new() { }

}
