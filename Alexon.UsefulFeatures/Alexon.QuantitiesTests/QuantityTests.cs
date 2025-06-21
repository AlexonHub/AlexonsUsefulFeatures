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
        public void OperatorsTest()
        {
            var length100 = Length<Meter>.Init(100);
            var length200 = Length<Meter>.Init(200);
            var length300 = Length<Meter>.Init(300);

            (length100 + length200).QuantityValue.Should().Be(300);
            (length100 - length200).QuantityValue.Should().Be(-100);
            (length200 - 100).QuantityValue.Should().Be(100);
            (length200 + 100).QuantityValue.Should().Be(300);

            (length100 * 2).QuantityValue.Should().Be(200);
            (length200 / 2).QuantityValue.Should().Be(100);

            (length100 + length300 - length200).QuantityValue.Should().Be(200);

            var area = length100 * length200;
            area.QuantityValue.Should().Be(20000); 
            area.UnitSymbol.Should().Be("m^2");
            area.ToString().Should().Be("l = 20000 m^2");

            var volume = area * length100;
            volume.QuantityValue.Should().Be(2000000);
            volume.UnitSymbol.Should().Be("m^3");
            volume.ToString().Should().Be("l = 2000000 m^3");

            var x = (double)length100 / length200;
            x.Should().Be(0.5);

        }

        [Test()]
        public void ToStringTest()
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
            meters100.QuantityValue.Should().Be(100);
            meters100.ToString().Should().Be("l = 100 m");

            var kilometers10 = Length<Kilo, Meter>.Init(10);
            kilometers10.Should().BeOfType<Meter>();
            kilometers10.Prefix.Should().BeOfType<Kilo>();
            kilometers10.QuantityValue.Should().Be(10000);
            kilometers10.ToString().Should().Be("l = 10 km");

            var centimeters = Length<Centi, Meter>.Init(1);
            centimeters.Should().BeOfType<Meter>();
            centimeters.Prefix.Should().BeOfType<Centi>();
            centimeters.QuantityValue.Should().Be(0.01);
            centimeters.ToString().Should().Be("l = 1 cm");
            
        }

        [Test()]
        public void Dimensoins2Test()
        {
            var meters1000 = Length<Meter>.Init(1000);
            var areaMillionMeters = meters1000 * meters1000;
            areaMillionMeters.QuantityValue.Should().Be(1000000);
            areaMillionMeters.NaturalDegree.Should().Be(2);
            areaMillionMeters.UnitSymbol.Should().Be("m^2");
            areaMillionMeters.ToString().Should().Be("l = 1000000 m^2");

            var oneKilometer = Length<Kilo, Meter>.Init(1);
            var areaOneKiloMeter = oneKilometer * oneKilometer;
            areaOneKiloMeter.QuantityValue.Should().Be(1000000);
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
            dim4.QuantityValue.Should().Be(10000);
            dim4.NaturalDegree.Should().Be(4);
            dim4.UnitSymbol.Should().Be("m^4");
            dim4.ToString().Should().Be("l = 10000 m^4");

            var dim2 = dim4 / area100Meters;
            dim2.QuantityValue.Should().Be(100);
            dim2.NaturalDegree.Should().Be(2);
            dim2.UnitSymbol.Should().Be("m^2");
            dim2.ToString().Should().Be("l = 100 m^2");

            var dim1 = dim2 / dim2;
            dim1.QuantityValue.Should().Be(1);
            dim1.NaturalDegree.Should().Be(1);
            dim1.UnitSymbol.Should().Be("");
            dim1.ToString().Should().Be("");

        }

        [Test()]
        public void DimensoinsOperationsTest()
        {
            var oneKilometer = Length<Kilo, Meter>.Init(1);
            var dim3 = oneKilometer * oneKilometer * oneKilometer;
            dim3.QuantityValue.Should().Be(1000000000);
            dim3.NaturalDegree.Should().Be(3);
            dim3.UnitSymbol.Should().Be("m^3");
            dim3.ToString().Should().Be("l = 1 km^3");

            var areaOneKiloMeter = oneKilometer * oneKilometer;
            var oneKm = dim3 / areaOneKiloMeter;
            oneKm.QuantityValue.Should().Be(1000);
            oneKm.NaturalDegree.Should().Be(1);
            oneKm.UnitSymbol.Should().Be("m");
            oneKm.ToString().Should().Be("l = 1 km");

        }

        [Test()]
        public void DimensoinsDecimakOperationsTest()
        {
            var oneKilometer = Length<Kilo, Meter>.Init(1);
            var km0_25 = oneKilometer / 4;
            km0_25.QuantityValue.Should().Be(250);
            km0_25.NaturalDegree.Should().Be(1);
            km0_25.UnitSymbol.Should().Be("m");
            km0_25.ToString().Should().Be("l = 0.25 km");

            var m250 = (Meter)km0_25.ToMetric<Base>();
            m250.QuantityValue.Should().Be(250);
            m250.ToString().Should().Be("l = 250 m");

            var meter250 = Length<Meter>.Init(250);
            (km0_25.QuantityValue == meter250.QuantityValue).Should().BeTrue();

            (km0_25 == 250).Should().BeTrue();
            (meter250 == 250).Should().BeTrue();

            var kilometers10 = oneKilometer * 10;
            kilometers10.QuantityValue.Should().Be(10000);
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
            meters.QuantityValue.Should().Be(1500);
            meters.MetricValue.Should().Be(1500);
            meters.UnitSymbol.Should().Be("m");
            meters.MetricUnitSymbol.Should().Be("m");
            meters.ToString().Should().Be("l = 1500 m");

            var kilometers = meters.ToMetric<Kilo>();
            kilometers.Prefix.Should().BeOfType<Kilo>();
            kilometers.QuantityValue.Should().Be(1500);
            kilometers.MetricValue.Should().Be(1.5);
            kilometers.UnitSymbol.Should().Be("m");
            kilometers.MetricUnitSymbol.Should().Be("km");
            kilometers.ToString().Should().Be("l = 1.5 km");

            (meters.QuantityValue == kilometers.QuantityValue).Should().BeTrue();
        }
    
    }
}