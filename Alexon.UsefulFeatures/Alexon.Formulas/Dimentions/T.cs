namespace Alexon.Formulas.Dimentions
{
    public record T(double Value) : Dim(Value)
    {
        public override string Name { get; set; } = "Time";
        public override string Symbol { get; set; } = "s";
    }
}
