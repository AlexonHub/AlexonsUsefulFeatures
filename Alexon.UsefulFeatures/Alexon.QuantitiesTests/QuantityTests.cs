using Alexon.Quantities;
using Alexon.Quantities.MeasuresAmountOfSubstance;
using Alexon.Quantities.MeasuresElectricCurrent;
using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresLuminousIntensity;
using Alexon.Quantities.MeasuresMass;
using Alexon.Quantities.MeasuresTemperature;
using Alexon.Quantities.MeasuresTime;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.QuantitiesTests
{
    [TestFixture()]
    public class QuantityTests
    {
        [Test()]
        public void WriteTest()
        {
            List<Quantity> quantities =
            [
                new Temperature(),
                new AmountOfSubstance(),
                new ElectricCurrent(),
                new LuminousIntensity(),
                new Length(),
                new Mass(),
                new Time()
            ];

            var descriptions = quantities.Select(q => q.Write());

            var expectedDescriptions = new List<string>
            {
                "T", // Temperature
                "n", // Amount of Substance
                "I", // Electric Current
                "Iv", // Luminous Intensity
                "l", // Length
                "m", // Mass
                "t"  // Time
            };

            descriptions.Should().BeEquivalentTo(expectedDescriptions);

        }

        [Test()]
        public void InitTest()
        {
            var meters = new Length().Set<Meter>(100);
            meters.BaseMeasure.Should().BeOfType<Length>();
            meters.BaseMeasure.Write().Should().Be("l");
            meters.Should().BeOfType<Meter>();
            meters.Prefix.Should().BeOfType<Base>(); ;
            meters.Value.Should().Be(100m);
            meters.Write().Should().Be("l = 100 m");

            var kilometers = new Length().Set<Kilo, Meter>(1);
            kilometers.BaseMeasure.Should().BeOfType<Length>();
            kilometers.Should().BeOfType<Meter>();
            kilometers.Prefix.Should().BeOfType<Kilo>();
            kilometers.Value.Should().Be(1000m);
            kilometers.Write().Should().Be("l = 1 km");

            var kilometers2 = new Length().SetPrefix<Kilo>().Set<Meter>(1m);
            kilometers2.BaseMeasure.Should().BeOfType<Length>();
            kilometers2.Should().BeOfType<Meter>();
            kilometers2.Prefix.Should().BeOfType<Kilo>();
            kilometers2.Value.Should().Be(1000m);
            kilometers2.Write().Should().Be("l = 1 km");

            var centimeters = new Length().SetPrefix<Centi>().Set<Meter>(1m);
            centimeters.BaseMeasure.Should().BeOfType<Length>();
            centimeters.Should().BeOfType<Meter>();
            centimeters.Prefix.Should().BeOfType<Centi>();
            centimeters.Value.Should().Be(0.01m);
            centimeters.Write().Should().Be("l = 1 cm");

        }

        [Test()]
        public void DimensoinsTest()
        {
            var meters10 = new Length().Set<Meter>(10);
            var areaMeters = meters10 * meters10;
            areaMeters.Value.Should().Be(100);
            //areaMeters.BaseMeasure.Should().BeOfType<Area>();
            //areaMeters.BaseMeasure.Write().Should().Be("S");
            areaMeters.Should().BeOfType<Meter>();
            areaMeters.Prefix.Should().BeOfType<Base>();
            areaMeters.NaturalDegree.Should().Be(2);
            areaMeters.UnitSymbol.Should().Be("m^2");
            areaMeters.Write().Should().Be("l = 100 m^2");

            var oneKilometer = new Length().SetPrefix<Kilo>().Set<Meter>(1);
            var areaOneKiloMeter = oneKilometer * oneKilometer;
            areaOneKiloMeter.Value.Should().Be(1000000);
            areaOneKiloMeter.UnitSymbol.Should().Be("m^2");
            areaOneKiloMeter.Write().Should().Be("l = 1 km^2");

            var dim4 = areaMeters * areaMeters;
            dim4.Value.Should().Be(10000);
            dim4.NaturalDegree.Should().Be(4);
            dim4.UnitSymbol.Should().Be("m^4");
            dim4.Write().Should().Be("l = 10000 m^4");

            var dim2 = dim4 / areaMeters;
            dim2.Value.Should().Be(100);
            dim2.NaturalDegree.Should().Be(2);
            dim2.UnitSymbol.Should().Be("m^2");
            dim2.Write().Should().Be("l = 100 m^2");

            var dim1 = dim2 / dim2;
            dim1.Value.Should().Be(1);
            dim1.NaturalDegree.Should().Be(1);
            dim1.UnitSymbol.Should().Be("m");
            dim1.Write().Should().Be("l = 1 m");

            var dim3 = oneKilometer * oneKilometer * oneKilometer;
            dim3.Value.Should().Be(1000000000);
            dim3.NaturalDegree.Should().Be(3);
            dim3.UnitSymbol.Should().Be("m^3");
            dim3.Write().Should().Be("l = 1 km^3");

            var oneKm = dim3 / areaOneKiloMeter;
            oneKm.Value.Should().Be(1000);
            oneKm.NaturalDegree.Should().Be(1);
            oneKm.UnitSymbol.Should().Be("m");
            oneKm.Write().Should().Be("l = 1 km");    

            var km0_25 = oneKilometer/4;
            km0_25.Value.Should().Be(250);
            km0_25.NaturalDegree.Should().Be(1);
            km0_25.UnitSymbol.Should().Be("m");
            km0_25.Write().Should().Be("l = 0,25 km");

            var m250 = (Meter)km0_25.SetPrefix<Base>();
            m250.Value.Should().Be(250);
            m250.Write().Should().Be("l = 250 m");

            Meter meter250 = new Length().Set<Meter>(250);
            (km0_25 == meter250).Should().BeTrue();

            (km0_25 == 250m).Should().BeTrue();
            (meter250 == 250m).Should().BeTrue();

            var meters100 = meters10 * 10;
            meters100.Value.Should().Be(100);
            meters100.Write().Should().Be("l = 100 m");

        }

    }
}