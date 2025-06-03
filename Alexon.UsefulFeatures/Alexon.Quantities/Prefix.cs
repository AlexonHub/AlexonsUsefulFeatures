namespace Alexon.Quantities
{
    public class Prefix
    {
        public string Symbol { get; set; } = null!;
        public int Power { get; set; } 

        public decimal Get(decimal value) => value / (decimal)Math.Pow(10, Power);
        public decimal Set(decimal value) => value * (decimal)Math.Pow(10, Power);

        public static Prefix operator +(Prefix left, Prefix right) => CreatePrefixFromPower(left.Power + right.Power);
        public static Prefix operator -(Prefix left, Prefix right) => CreatePrefixFromPower(left.Power - right.Power);

        private static Prefix CreatePrefixFromPower(int power)
        {
            return power switch
            {
                30 => new Quetta(),
                27 => new Ronna(),
                24 => new Yotta(),
                21 => new Zetta(),
                18 => new Exa(),
                15 => new Peta(),
                12 => new Tera(),
                9 => new Giga(),
                6 => new Mega(),
                3 => new Kilo(),
                2 => new Hecto(),
                1 => new Deca(),
                0 => new Base(),
                -1 => new Deci(),
                -2 => new Centi(),
                -3 => new Milli(),
                -6 => new Micro(),
                -9 => new Nano(),
                -12 => new Pico(),
                -15 => new Femto(),
                -18 => new Atto(),
                -21 => new Zepto(),
                -24 => new Yocto(),
                -27 => new Ronto(),
                -30 => new Quecto(),
                _ => new Prefix() { Power = power, Symbol = $"d{power}" }
            };
        }
    }

    public class Quetta : Prefix { public Quetta() { Symbol = "Q"; Power = 30; } }
    public class Ronna : Prefix { public Ronna() { Symbol = "R"; Power = 27; } }
    public class Yotta : Prefix { public Yotta() { Symbol = "Y"; Power = 24; } }
    public class Zetta : Prefix { public Zetta() { Symbol = "Z"; Power = 21; } }
    public class Exa : Prefix { public Exa() { Symbol = "E"; Power = 18; } }
    public class Peta : Prefix { public Peta() { Symbol = "P"; Power = 15; } }
    public class Tera : Prefix { public Tera() { Symbol = "T"; Power = 12; } }
    public class Giga : Prefix { public Giga() { Symbol = "G"; Power = 9; } }
    public class Mega : Prefix { public Mega() { Symbol = "M"; Power = 6; } }
    public class Kilo : Prefix { public Kilo() { Symbol = "k"; Power = 3; } }
    public class Hecto : Prefix { public Hecto() { Symbol = "h"; Power = 2; } }
    public class Deca : Prefix { public Deca() { Symbol = "da"; Power = 1; } }
    public class Base : Prefix { public Base() { Symbol = ""; Power = 0; } }
    public class Deci : Prefix { public Deci() { Symbol = "d"; Power = -1; } }
    public class Centi : Prefix { public Centi() { Symbol = "c"; Power = -2; } }
    public class Milli : Prefix { public Milli() { Symbol = "m"; Power = -3; } }
    public class Micro : Prefix { public Micro() { Symbol = "µ"; Power = -6; } }
    public class Nano : Prefix { public Nano() { Symbol = "n"; Power = -9; } }
    public class Pico : Prefix { public Pico() { Symbol = "p"; Power = -12; } }
    public class Femto : Prefix { public Femto() { Symbol = "f"; Power = -15; } }
    public class Atto : Prefix { public Atto() { Symbol = "a"; Power = -18; } }
    public class Zepto : Prefix { public Zepto() { Symbol = "z"; Power = -21; } }
    public class Yocto : Prefix { public Yocto() { Symbol = "y"; Power = -24; } }
    public class Ronto : Prefix { public Ronto() { Symbol = "r"; Power = -27; } }
    public class Quecto : Prefix { public Quecto() { Symbol = "q"; Power = -30; } }


}
