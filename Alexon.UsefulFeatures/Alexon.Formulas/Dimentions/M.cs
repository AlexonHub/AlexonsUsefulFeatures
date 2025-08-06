namespace Alexon.Formulas.Dimentions
{
    public record M(double Value) : Dim(Value)
    {
        public override string Name { get; set; } = "Mass";
        public override string Symbol { get; set; } = "kg";

    }
}
