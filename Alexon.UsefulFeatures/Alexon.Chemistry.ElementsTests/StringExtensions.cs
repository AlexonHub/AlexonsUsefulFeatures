namespace Alexon.Chemistry.Elements.Tests
{
    public static class StringExtensions
    {
        public static List<Atom> ConvertToAtoms(this string formula)
        {
            var atoms = new List<Atom>();

            foreach (char c in formula.ToCharArray())
            {
                switch (c)
                {
                    case 'C':
                        atoms.Add(new Carbon());
                        break;
                    case 'H':
                        atoms.Add(new Hydrogen());
                        break;
                    case 'O':
                        atoms.Add(new Oxygen());
                        break;
                    default:
                        throw new ArgumentException($"Unsupported element symbol: {c}");
                }
            }

            return atoms;
        }
    }
}