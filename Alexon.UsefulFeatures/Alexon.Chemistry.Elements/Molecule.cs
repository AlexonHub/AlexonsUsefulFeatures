namespace Alexon.Chemistry.Elements
{
    public class Molecule
    {
        public string Name { get; set; }
        public List<Atom> Elements { get; set; }
        public double MolecularWeight => Elements.Sum(e => e.RelativeAtomicMass);
        public Molecule(string name, List<Atom> elements)
        {
            Name = name;
            Elements = elements;
        }
        public override string ToString()
        {
            return $"{Name} ({string.Join(", ", Elements.Select(x=>x.Symbol))}) - Molecular Weight: {MolecularWeight}";
        }
    }
}
