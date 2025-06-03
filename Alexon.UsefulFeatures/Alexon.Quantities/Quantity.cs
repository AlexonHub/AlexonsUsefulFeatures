namespace Alexon.Quantities
{
    public abstract class Quantity
    {
        public abstract string Measure { get; }
        public abstract string Description { get; }
        public abstract string DimensionSymbol { get; }
        public abstract string QuantitySymbol { get; }

        protected string? unitSymbol;
        public virtual string UnitSymbol
        {
            get => NaturalDegree != 1 ? $"{unitSymbol}^{NaturalDegree}" : unitSymbol ?? string.Empty;
            set => unitSymbol = value;
        }

        public Prefix Prefix { get; set; } = new Base();
        public virtual int NaturalDegree { get; set; } = 1;
        public virtual decimal Value { get; set; }

        public Quantity BaseMeasure { get; set; } =  null!;

        public string Text { get { return Write(); } }
    
        public string Write()
        {
            if (string.IsNullOrEmpty(UnitSymbol))
            {
                return QuantitySymbol;
            }

            decimal val = NaturalDegree != 1
                    ? (decimal)Math.Pow(10, NaturalDegree)
                    : Value;

            if (Prefix is null)
            {
                return $"{QuantitySymbol} = {val:G29} {UnitSymbol}";
            }
            else
            {
                val = Value / (decimal)Math.Pow(10, NaturalDegree * Prefix.Power);

                return $"{QuantitySymbol} = {val:G29} {Prefix.Symbol}{UnitSymbol}";
            }
        }

        override public string ToString()
        {
            return Write();
        }

        #region Operators
        //public static Quantity operator +(Quantity a) => a;

        //public static Quantity operator -(Quantity quantity)
        //{
        //    quantity.Value = -quantity.Value;
        //    return quantity;
        //}

        //public static Quantity operator +(Quantity left, Quantity right)
        //{
        //    if (left.Measure != right.Measure)
        //    {
        //        throw new InvalidOperationException($"Cannot add quantities of different measures: {left.Measure} and {right.Measure}.");
        //    }

        //    left.Value += right.Value;
        //    return left;
        //}

        //public static Quantity operator -(Quantity left, Quantity right)
        //{
        //    if (left.Measure != right.Measure)
        //    {
        //        throw new InvalidOperationException($"Cannot add quantities of different measures: {left.Measure} and {right.Measure}.");
        //    }

        //    left.Value -= right.Value;
        //    return left;
        //}

        //public static implicit operator decimal(Quantity quantity) => quantity.Value;

        ////public static explicit operator Length<T>(decimal value) => Length<T>.Set(value) ;

        public static Quantity operator *(Quantity left, Quantity right)
        {
            var naturalDegree = left.NaturalDegree + right.NaturalDegree;
            if (naturalDegree == 0) { naturalDegree = 1; }

            if (left.Measure == right.Measure)
            {
                var newQuantity = left.ShallowCopy();
                newQuantity.Value *= right.Value;
                newQuantity.NaturalDegree = naturalDegree;
                newQuantity.Prefix = left.Prefix;
                return newQuantity;
            }

            return new DerivedQuantity
            {
                Left = left.ShallowCopy(),
                Right = right.ShallowCopy(),
                Value = left.Value * right.Value,
                Prefix = left.Prefix,
                UnitSymbol = $"{left.UnitSymbol}*{right.UnitSymbol}",
                NaturalDegree = naturalDegree,
                Operator = "times",
            };
        }

        public static Quantity operator /(Quantity left, Quantity right)
        {
            if (right.Value == 0) throw new DivideByZeroException("Cannot divide by zero.");
            
            var naturalDegree = left.NaturalDegree - right.NaturalDegree;
            if (naturalDegree == 0) { naturalDegree = 1; }
           
            if (left.Measure == right.Measure)
            {
                var newQuantity = left.ShallowCopy();
                newQuantity.Value /= right.Value;
                newQuantity.NaturalDegree = naturalDegree;
                newQuantity.Prefix = left.Prefix;
                return newQuantity;
            }

            return new DerivedQuantity
            {
                Left = left.ShallowCopy(),
                Right = right.ShallowCopy(),
                Value = left.Value / right.Value,
                Prefix = left.Prefix,
                UnitSymbol = $"{left.UnitSymbol}/{right.UnitSymbol}",
                NaturalDegree = naturalDegree,
                Operator = "per",
            };
        }

        public static Quantity operator *(Quantity left, decimal number)
        {
            var newQuantity = left.ShallowCopy();
            newQuantity.Value *= number;
            return newQuantity;
        }        
    
        public static Quantity operator /(Quantity left, decimal number)
        {
            if (number == 0) throw new DivideByZeroException("Cannot divide by zero.");
            var newQuantity = left.ShallowCopy();
            newQuantity.Value /= number;
            return newQuantity;
        }

        public static bool operator ==(Quantity left, decimal right)
        {
            return left.Value == right;
        }

        public static bool operator !=(Quantity left, decimal right)
        {
            return left.Value != right;
        }

        public static bool operator ==(Quantity left, Quantity right)
        {
            return left.Equals(right);  
        }

        public static bool operator !=(Quantity left, Quantity right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Quantity quantity &&
                   Measure == quantity.Measure &&
                   NaturalDegree == quantity.NaturalDegree &&
                   Value == quantity.Value &&
                   Prefix.Power == quantity.Prefix.Power &&
                   EqualityComparer<Quantity>.Default.Equals(BaseMeasure, quantity.BaseMeasure);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Measure);
            hash.Add(Description);
            hash.Add(DimensionSymbol);
            hash.Add(QuantitySymbol);
            hash.Add(unitSymbol);
            hash.Add(UnitSymbol);
            hash.Add(Prefix);
            hash.Add(NaturalDegree);
            hash.Add(Value);
            hash.Add(BaseMeasure);
            return hash.ToHashCode();
        }
    
        public Quantity ShallowCopy()
        {
            return (Quantity)MemberwiseClone();
        }

        #endregion
    }
}