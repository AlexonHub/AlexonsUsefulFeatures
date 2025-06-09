using Alexon.Quantities;
using Alexon.Quantities.MeasuresAmountOfSubstance;
using Alexon.Quantities.MeasuresElectricCurrent;
using Alexon.Quantities.MeasuresLength;
using Alexon.Quantities.MeasuresLength.SI;
using Alexon.Quantities.MeasuresLuminousIntensity;
using Alexon.Quantities.MeasuresMass;
using Alexon.Quantities.MeasuresTemperature;
using Alexon.Quantities.MeasuresTime;
using Alexon.Quantities.Prefixes;
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
            var meters100 = Length<Meter>.Init(100);
            meters100.Should().BeOfType<Meter>();
            meters100.Prefix.Should().BeOfType<Base>(); ;
            meters100.Value.Should().Be(100m);
            meters100.ToString().Should().Be("l = 100 m");

            var kilometers10 = Length<Kilo, Meter>.Init(10);
            kilometers10.Should().BeOfType<Meter>();
            kilometers10.Prefix.Should().BeOfType<Kilo>();
            kilometers10.Value.Should().Be(10000m);
            kilometers10.ToString().Should().Be("l = 10 km");

            var centimeters = Length<Centi, Meter>.Init(1);
            centimeters.Should().BeOfType<Meter>();
            centimeters.Prefix.Should().BeOfType<Centi>();
            centimeters.Value.Should().Be(0.01m);
            centimeters.ToString().Should().Be("l = 1 cm");
            
        }

        [Test()]
        public void Dimensoins2Test()
        {
            var meters1000 = Length<Meter>.Init(1000);
            var areaMillionMeters = meters1000 * meters1000;
            areaMillionMeters.Value.Should().Be(1000000);
            areaMillionMeters.NaturalDegree.Should().Be(2);
            areaMillionMeters.UnitSymbol.Should().Be("m^2");
            areaMillionMeters.ToString().Should().Be("l = 1000000 m^2");

            var oneKilometer = Length<Kilo, Meter>.Init(1);
            var areaOneKiloMeter = oneKilometer * oneKilometer;
            areaOneKiloMeter.Value.Should().Be(1000000);
            areaOneKiloMeter.UnitSymbol.Should().Be("m^2");
            areaOneKiloMeter.NaturalDegree.Should().Be(2);
            areaOneKiloMeter.MetricValue.Should().Be(1);
            areaOneKiloMeter.ToString().Should().Be("l = 1 km^2");
        }

        [Test()]
        public void Dimensoins4Test()
        {
            var meters10 = Length<Meter>.Init(10);
            var area100Meters = meters10 * meters10;
            var dim4 = area100Meters * area100Meters;
            dim4.Value.Should().Be(10000);
            dim4.NaturalDegree.Should().Be(4);
            dim4.UnitSymbol.Should().Be("m^4");
            dim4.ToString().Should().Be("l = 10000 m^4");

            var dim2 = dim4 / area100Meters;
            dim2.Value.Should().Be(100);
            dim2.NaturalDegree.Should().Be(2);
            dim2.UnitSymbol.Should().Be("m^2");
            dim2.ToString().Should().Be("l = 100 m^2");

            var dim1 = dim2 / dim2;
            dim1.Value.Should().Be(1);
            dim1.NaturalDegree.Should().Be(1);
            dim1.UnitSymbol.Should().Be("m");
            dim1.ToString().Should().Be("l = 1 m");
        }

        [Test()]
        public void DimensoinsOperationsTest()
        {
            var oneKilometer = Length<Kilo, Meter>.Init(1);
            var dim3 = oneKilometer * oneKilometer * oneKilometer;
            dim3.Value.Should().Be(1000000000);
            dim3.NaturalDegree.Should().Be(3);
            dim3.UnitSymbol.Should().Be("m^3");
            dim3.ToString().Should().Be("l = 1 km^3");

            var areaOneKiloMeter = oneKilometer * oneKilometer;
            var oneKm = dim3 / areaOneKiloMeter;
            oneKm.Value.Should().Be(1000);
            oneKm.NaturalDegree.Should().Be(1);
            oneKm.UnitSymbol.Should().Be("m");
            oneKm.ToString().Should().Be("l = 1 km");

        }

        [Test()]
        public void DimensoinsDecimakOperationsTest()
        {
            var oneKilometer = Length<Kilo, Meter>.Init(1);
            var km0_25 = oneKilometer / 4;
            km0_25.Value.Should().Be(250);
            km0_25.NaturalDegree.Should().Be(1);
            km0_25.UnitSymbol.Should().Be("m");
            km0_25.ToString().Should().Be("l = 0.25 km");

            var m250 = (Meter)km0_25.ToMetric<Base>();
            m250.Value.Should().Be(250);
            m250.ToString().Should().Be("l = 250 m");

            var meter250 = Length<Meter>.Init(250);
            (km0_25.Value == meter250.Value).Should().BeTrue();

            (km0_25 == 250m).Should().BeTrue();
            (meter250 == 250m).Should().BeTrue();

            var kilometers10 = oneKilometer * 10;
            kilometers10.Value.Should().Be(10000);
            kilometers10.MetricValue.Should().Be(10);
            kilometers10.UnitSymbol.Should().Be("m");
            kilometers10.MetricUnitSymbol.Should().Be("km");
            kilometers10.ToString().Should().Be("l = 10 km");

        }

        [Test()]
        public void DecimalConversionTest()
        {
            var meters = Length<Meter>.Init(1500);
            meters.Prefix.Should().BeOfType<Base>();
            meters.Value.Should().Be(1500);
            meters.MetricValue.Should().Be(1500);
            meters.UnitSymbol.Should().Be("m");
            meters.MetricUnitSymbol.Should().Be("m");
            meters.ToString().Should().Be("l = 1500 m");

            var kilometers = meters.ToMetric<Kilo>();
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