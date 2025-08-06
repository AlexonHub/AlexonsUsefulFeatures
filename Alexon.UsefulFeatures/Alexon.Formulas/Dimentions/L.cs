namespace Alexon.Formulas.Dimentions
{
    public record L(double Value) : Dim(Value)
    {
        public override string Name { get; set; } = "Length";
        public override string Symbol { get; set; } = "m";
    }
}
