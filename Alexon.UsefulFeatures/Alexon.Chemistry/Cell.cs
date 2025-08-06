using Alexon.Chemistry.Nucleotides;

namespace Alexon.Chemistry
{
    public class Cell
    {
        public static int EnergyUnits { get; set; }
        public List<Protein> Proteins { get; set; } = [];
        public DNA CellDNA { get; set; } 
        public RNA CellRNA { get; set; }

        public Cell(List<Nucleotide> strand)
        {
            CellDNA = new DNA(strand);
        }

        public Cell(string genome)
        {
            List<Nucleotide> strand = [];
            strand.FillFromString(genome);
            EnergyUnits = genome.Length;
            CellDNA = new DNA(strand);
        }

        public static Nucleotide? Synthesize<T>() where T : Nucleotide, new()
        {
            if (EnergyUnits > 0)
            {
                EnergyUnits--;
                return new T();
            }
            return null;
        }

        public void FeedOn(int energyUnits) 
        { 
            EnergyUnits = energyUnits;
        }

        public Cell Split() 
        {
            List<Nucleotide> strand = CellDNA.SplitDNA(); 
            Cell newCell = new Cell(strand);
            return newCell;
        }

        public void Transcript()
        {
            CellRNA = new RNA();
            foreach (var nucleotide in CellDNA.FirstStrand)
            {
                switch (nucleotide)
                {
                    case Adenine:
                        CellRNA.Strand.Add(new Uracil());
                        break;
                    case Cytosine:
                        CellRNA.Strand.Add(new Guanine());
                        break;
                    case Thymine:
                        CellRNA.Strand.Add(new Adenine());
                        break;
                    case Guanine:
                        CellRNA.Strand.Add(new Cytosine());
                        break;
                }
            }
        }

        public void Translate()
        {
            //MET-LEU-LYS-VAL
            var triplets = CellRNA.Strand.Chunk(3);
            foreach (var triplet in triplets)
            {
                var codon = string.Join("", triplet.Select(x => x.ID.First()));
                var protein = Protein.GetProtein(codon);
                Proteins.Add(protein);
            }
        }
    }
}
