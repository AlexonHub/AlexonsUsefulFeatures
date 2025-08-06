using FluentAssertions;
using NUnit.Framework;

namespace Alexon.Chemistry.Tests
{
    [TestFixture()]
    public class ProteinTests
    {
        [Test()]
        public void GetProteinTest()
        {
            var codon = "AUG";
            var protein = Protein.GetProtein(codon);
            protein?.Name.Should().Be("Methionine");
        }
    }
}