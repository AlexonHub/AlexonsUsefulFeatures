namespace Alexon.Chemistry
{
    public class Protein
    {
        public string? Name { get; set; }

        public static Protein? GetProtein(string codon)
        {
            var proteinMapping = new Dictionary<string, string>
            {
                {"UUU", "Phenylalanine"}, 
                {"UUC", "Phenylalanine"},
                {"UUA", "Leucine"}, 
                {"UUG", "Leucine"},
                {"CUU", "Leucine"}, 
                {"CUC", "Leucine"}, 
                {"CUA", "Leucine"}, 
                {"CUG", "Leucine"},
                {"AUU", "Isoleucine"}, 
                {"AUC", "Isoleucine"}, 
                {"AUA", "Isoleucine"},
                {"AUG", "Methionine"},
                {"GUU", "Valine"}, 
                {"GUC", "Valine"}, 
                {"GUA", "Valine"}, 
                {"GUG", "Valine"},
                {"UCU", "Serine"}, 
                {"UCC", "Serine"}, 
                {"UCA", "Serine"}, 
                {"UCG", "Serine"},
                {"CCU", "Proline"}, 
                {"CCC", "Proline"}, 
                {"CCA", "Proline"}, 
                {"CCG", "Proline"},
                {"ACU", "Threonine"}, 
                {"ACC", "Threonine"}, 
                {"ACA", "Threonine"},
                {"ACG", "Threonine"},
                {"GCU", "Alanine"}, 
                {"GCC", "Alanine"}, 
                {"GCA", "Alanine"}, 
                {"GCG", "Alanine"},
                {"UAU", "Tyrosine"}, 
                {"UAC", "Tyrosine"},
                {"UAA", "Stop"}, 
                {"UAG", "Stop"}, 
                {"UGA", "Stop"},
                {"CAU", "Histidine"}, 
                {"CAC", "Histidine"},
                {"CAA", "Glutamine"}, 
                {"CAG", "Glutamine"},
                {"AAU", "Asparagine"}, 
                {"AAC", "Asparagine"},
                {"AAA", "Lysine"}, 
                {"AAG", "Lysine"},
                {"GAU", "Aspartic Acid"},
                {"GAC", "Aspartic Acid"},
                {"GAA", "Glutamic Acid"}, 
                {"GAG", "Glutamic Acid"},
                {"UGU", "Cysteine"}, 
                {"UGC", "Cysteine"},
                {"UGG", "Tryptophan"},
                {"CGU", "Arginine"},
                {"CGC", "Arginine"}, 
                {"CGA", "Arginine"}, 
                {"CGG", "Arginine"},
                {"AGU", "Serine"}, 
                {"AGC", "Serine"},
                {"AGA", "Arginine"}, 
                {"AGG", "Arginine"},
                {"GGU", "Glycine"}, 
                {"GGC", "Glycine"}, 
                {"GGA", "Glycine"}, 
                {"GGG", "Glycine"}
            };

            if (proteinMapping.TryGetValue(codon, out var name))
            {
                return new Protein { Name = name };
            }

            return null;
        }
    }
}