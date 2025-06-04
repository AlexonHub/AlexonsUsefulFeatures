using Alexon.Quantities.Base;
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

            var descriptions = quantities.Select(q => q.ToString());

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
            var meter = Length.Init<Meter>(25);

            var meters = new Length().Set<Meter>(100);
            meters.Should().BeOfType<Meter>();
            meters.Prefix.Should().BeOfType<Base>(); ;
            meters.Value.Should().Be(100m);
            meters.ToString().Should().Be("l = 100 m");

            var kilometers = new Length().Set<Kilo, Meter>(1);
            kilometers.Should().BeOfType<Meter>();
            kilometers.Prefix.Should().BeOfType<Kilo>();
            kilometers.Value.Should().Be(1000m);
            kilometers.ToString().Should().Be("l = 1 km");

            var kilometers2 = new Length().SetPrefix<Kilo>().Set<Meter>(1m);
            kilometers2.Should().BeOfType<Meter>();
            kilometers2.Prefix.Should().BeOfType<Kilo>();
            kilometers2.Value.Should().Be(1000m);
            kilometers2.ToString().Should().Be("l = 1 km");

            var centimeters = new Length().SetPrefix<Centi>().Set<Meter>(1m);
            centimeters.Should().BeOfType<Meter>();
            centimeters.Prefix.Should().BeOfType<Centi>();
            centimeters.Value.Should().Be(0.01m);
            centimeters.ToString().Should().Be("l = 1 cm");

        }

        [Test()]
        public void DimensoinsTest()
        {
            var meters10 = new Length().Set<Meter>(10);
            var areaMeters = meters10 * meters10;
            areaMeters.Value.Should().Be(100);
            //areaMeters.BaseMeasure.Should().BeOfType<Area>();
            //areaMeters.BaseMeasure.ToString().Should().Be("S");
            areaMeters.Should().BeOfType<Meter>();
            areaMeters.Prefix.Should().BeOfType<Base>();
            areaMeters.NaturalDegree.Should().Be(2);
            areaMeters.UnitSymbol.Should().Be("m^2");
            areaMeters.ToString().Should().Be("l = 100 m^2");

            var oneKilometer = new Length().SetPrefix<Kilo>().Set<Meter>(1);
            var areaOneKiloMeter = oneKilometer * oneKilometer;
            areaOneKiloMeter.Value.Should().Be(1000000);
            areaOneKiloMeter.UnitSymbol.Should().Be("m^2");
            areaOneKiloMeter.ToString().Should().Be("l = 1 km^2");

            var dim4 = areaMeters * areaMeters;
            dim4.Value.Should().Be(10000);
            dim4.NaturalDegree.Should().Be(4);
            dim4.UnitSymbol.Should().Be("m^4");
            dim4.ToString().Should().Be("l = 10000 m^4");

            var dim2 = dim4 / areaMeters;
            dim2.Value.Should().Be(100);
            dim2.NaturalDegree.Should().Be(2);
            dim2.UnitSymbol.Should().Be("m^2");
            dim2.ToString().Should().Be("l = 100 m^2");

            var dim1 = dim2 / dim2;
            dim1.Value.Should().Be(1);
            dim1.NaturalDegree.Should().Be(1);
            dim1.UnitSymbol.Should().Be("m");
            dim1.ToString().Should().Be("l = 1 m");

            var dim3 = oneKilometer * oneKilometer * oneKilometer;
            dim3.Value.Should().Be(1000000000);
            dim3.NaturalDegree.Should().Be(3);
            dim3.UnitSymbol.Should().Be("m^3");
            dim3.ToString().Should().Be("l = 1 km^3");

            var oneKm = dim3 / areaOneKiloMeter;
            oneKm.Value.Should().Be(1000);
            oneKm.NaturalDegree.Should().Be(1);
            oneKm.UnitSymbol.Should().Be("m");
            oneKm.ToString().Should().Be("l = 1 km");

            var km0_25 = oneKilometer / 4;
            km0_25.Value.Should().Be(250);
            km0_25.NaturalDegree.Should().Be(1);
            km0_25.UnitSymbol.Should().Be("m");
            km0_25.ToString().Should().Be("l = 0.25 km");

            var m250 = (Meter)km0_25.SetPrefix<Base>();
            m250.Value.Should().Be(250);
            m250.ToString().Should().Be("l = 250 m");

            Meter meter250 = new Length().Set<Meter>(250);
            (km0_25 == meter250).Should().BeTrue();

            (km0_25 == 250m).Should().BeTrue();
            (meter250 == 250m).Should().BeTrue();

            var meters100 = meters10 * 10;
            meters100.Value.Should().Be(100);
            meters100.ToString().Should().Be("l = 100 m");

        }

        [Test()]
        public void DecimalConversionTest()
        {
            var meters = new Length().Set<Meter>(1500);
            meters.Prefix.Should().BeOfType<Base>();
            meters.Value.Should().Be(1500);
            meters.MetricValue.Should().Be(1500);
            meters.UnitSymbol.Should().Be("m");
            meters.MetricUnitSymbol.Should().Be("m");
            meters.ToString().Should().Be("l = 1500 m");


            var kilometers = meters.ToDecimal<Kilo>();
            kilometers.Prefix.Should().BeOfType<Kilo>();
            kilometers.Value.Should().Be(1500);
            kilometers.MetricValue.Should().Be(1.5m);
            kilometers.UnitSymbol.Should().Be("m");
            kilometers.MetricUnitSymbol.Should().Be("km");
            kilometers.ToString().Should().Be("l = 1.5 km");

            (meters.Value == kilometers.Value).Should().BeTrue();
        }
    }
}