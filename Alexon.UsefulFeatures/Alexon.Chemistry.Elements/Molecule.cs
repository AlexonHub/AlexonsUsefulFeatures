namespace Alexon.Chemistry.Elements
{
    public class Molecule(string name, List<Atom> elements)
    {
        public string Name { get; set; } = name;
        public List<Atom> Elements { get; set; } = elements;
        public double MolecularWeight => Elements.Sum(e => e.RelativeAtomicMass);

        public override string ToString()
        {
            return $"{Name} ({string.Join(", ", Elements.Select(x=>x.Symbol))}) - Molecular Weight: {MolecularWeight}";
        }
    }
}
