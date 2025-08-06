using Alexon.Chemistry.Nucleotides;

namespace Alexon.Chemistry
{
    public static class OrganicChemistryExtensions
    {
        public static string GetProteins(this Cell cell)
        {
            var result = string.Join("-", cell.Proteins.Select(x => x.Name));
            return result;
        }

        public static List<Nucleotide> FillFromString(this List<Nucleotide> list, string genome)
        {
            genome = genome.ToUpper().Replace("-", "");
            foreach (var item in genome)
            {
                switch (item)
                {
                    case 'A':
                    case 'А':
                        list.Add(new Adenine());
                        break;
                    case 'C':
                    case 'Ц':
                        list.Add(new Cytosine());
                        break;
                    case 'G':
                    case 'Г':
                        list.Add(new Guanine());
                        break;
                    case 'T':
                    case 'Т':
                        list.Add(new Thymine());
                        break;
                    case 'U':
                    case 'У':
                        list.Add(new Uracil());
                        break;
                }
            } 
            return list;
        }
    }
}
