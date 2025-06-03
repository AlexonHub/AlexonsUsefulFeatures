namespace Alexon.Quantities
{
    public class DerivedQuantity : Quantity
    {
        public string Operator { get; set; } = string.Empty;
        public override string Measure
        {
            get
            {
                var measures = derivedQuantities.FirstOrDefault(kv => kv.Value.Measure == Description);
                return measures.Key ?? Description;
            }
        }

        public override string Description => $"{Left.Measure} {Operator} {Right.Measure}";

        public override string DimensionSymbol => QuantitySymbol.ToUpper();

        public override string QuantitySymbol
        {
            get
            {
                var measures = derivedQuantities.FirstOrDefault(kv => kv.Value.Measure == Description);
                return measures.Value.QuantitySymbol ?? Description;
            }
        }

        public override string UnitSymbol
        {
            get
            {
                var measure = derivedQuantities.FirstOrDefault(kv => kv.Value.Measure == Description);
                return measure.Value.UnitSymbol ?? $"({base.UnitSymbol})";
            }
            set => unitSymbol = value;
        }
        public override decimal Value { get; set; }

        public override int NaturalDegree { get; set; }

        public Quantity Left { get; set; } = null!;
        public Quantity Right { get; set; } = null!;
        public Dictionary<string, (string QuantitySymbol, string Measure, string? UnitSymbol)> derivedQuantities = new Dictionary<string, (string QuantitySymbol, string Measure, string? UnitSymbol)>
                {
                    { "Speed", ("v", "Length per Time", default) },
                    { "Acceleration", ("a", "Speed per Time", default) },
                    { "Force", ("f", "Mass times Acceleration", "N") },
                    { "Energy", ("E", "Force times Length", default) },
                    { "Power", ("P", "Energy per Time", default) },
                    { "Pressure", ("p", "Force per Area", "Pa") },
                    { "VolumeFlowRate", ("Q", "Volume per Time", default) },
                    { "Density", ("d", "Mass per Volume", default) }
                };

        public string Result
        {
            get
            {
                return $"{Left.Value} {Left.UnitSymbol} {Operator} {Right.Value} {Right.UnitSymbol} = {Value} {UnitSymbol}";
            }
        }

    }
}