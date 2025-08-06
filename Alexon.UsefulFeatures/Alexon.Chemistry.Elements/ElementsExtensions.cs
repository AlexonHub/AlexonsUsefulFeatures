using System.Text.Json;

namespace Alexon.Chemistry.Elements
{
    public class ElementsExtensions
    {
        public static string MostCommonIsotopsJson => File.ReadAllText("most_common_isotopes.json");
        public static Dictionary<string, string> GetMostCommonIsotopes()
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(MostCommonIsotopsJson)
            ?? new Dictionary<string, string>();
        }
    }
}
