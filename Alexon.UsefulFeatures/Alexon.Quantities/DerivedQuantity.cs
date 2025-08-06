using System.Linq.Expressions;

namespace Alexon.Quantities
{
    public class DerivedQuantity : Quantity
    {
        public ExpressionType Operator { get; set; }

        public override string Measure => derivedQuantities.FirstOrDefault(kv => kv.Value.Measure == Description).Key ?? Description;

        public override string Description
        {
            get
            {
                string op = (Operator == ExpressionType.Divide) ? "per" : "times";
                return $"{Left.Measure} {op} {Right.Measure}";
            }
        }

        public override string DimensionSymbol => QuantitySymbol.ToUpper();

        public override string QuantitySymbol => derivedQuantities.FirstOrDefault(kv => kv.Value.Measure == Description).Value.QuantitySymbol ?? Description;

        public override string UnitSymbol
        {
            get => derivedQuantities.FirstOrDefault(kv => kv.Value.Measure == Description).Value.UnitSymbol ?? $"{base.UnitSymbol}";
            set => unitSymbol = value;
        }

        public override double QuantityValue { get; set; }

        public override int NaturalDegree { get; set; }

        public Quantity Left { get; set; } = null!;
        public Quantity Right { get; set; } = null!;

        public Dictionary<string, (string QuantitySymbol, string Measure, string? UnitSymbol)> derivedQuantities = new()
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

        public string Result => $"{Left.QuantityValue} {Left.UnitSymbol} {Operator} {Right.QuantityValue} {Right.UnitSymbol} = {QuantityValue} {UnitSymbol}";

        public override Quantity ToMetric<P>()
        {
            var newQuantity = (DerivedQuantity)ShallowCopy();
            newQuantity.Left = newQuantity.Left.ToMetric<P>();
            newQuantity.Prefix = newQuantity.Left.Prefix;

            return newQuantity;
        }
    
    }
}