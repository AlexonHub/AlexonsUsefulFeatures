using Alexon.Chemistry.Nucleotides;

namespace Alexon.Chemistry
{
    public class DNA
    {
        public DNA(List<Nucleotide> strand)
        {
            FirstStrand = strand;
            Replicate();
        }

        public List<Nucleotide> FirstStrand { get; set; }
        public List<Nucleotide> SecondStrand { get; set; } = new List<Nucleotide>();

        public void Replicate()
        {
            foreach (var nucleotide in FirstStrand)
            {
                switch (nucleotide)
                {
                    case Adenine:
                        SecondStrand.Add(Cell.Synthesize<Thymine>());
                        break;
                    case Thymine:
                        SecondStrand.Add(Cell.Synthesize<Adenine>());
                        break;
                    case Cytosine:
                        SecondStrand.Add(Cell.Synthesize<Guanine>());
                        break;
                    case Guanine:
                        SecondStrand.Add(Cell.Synthesize<Cytosine>());
                        break;
                }
            }
        }

        public override string ToString()
        {
            var nucleotidesNames = string.Empty;
            foreach (var item in FirstStrand)
            {
                nucleotidesNames += item.ID;
            }
            return nucleotidesNames;
        }

        public List<Nucleotide> SplitDNA()
        {
            var strand =  new List<Nucleotide>(SecondStrand);
            SecondStrand = [];
            Replicate();
            return strand;
        }
    }
}
