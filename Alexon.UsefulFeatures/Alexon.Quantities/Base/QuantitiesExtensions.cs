namespace Alexon.Quantities.Base
{
    public static class QuantitiesExtensions
    {
        public static V Set<V>(this Quantity quantity, decimal value) where V : Quantity, new()
        {
            V newQuantity = new()
            {
                BaseMeasure = (Quantity)Activator.CreateInstance(quantity.GetType()),
                NaturalDegree = quantity.NaturalDegree,
                Prefix = quantity.Prefix,
                Value = quantity.Value == 0 ? quantity.Prefix.Set(value) : value
            };
            return newQuantity;
        }

        public static V Set<P, V>(this Quantity quantity, decimal value) where P : Prefix, new() where V : Quantity, new()
        {
            quantity.Prefix = new P();
            return quantity.Set<V>(value);
        }

        public static Quantity SetPrefix<P>(this Quantity quantity) where P : Prefix, new()
        {
            quantity.Prefix = new P();
            return quantity;
        }
    }
}
