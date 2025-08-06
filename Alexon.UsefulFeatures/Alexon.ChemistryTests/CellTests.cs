using Alexon.Chemistry;
using Alexon.Chemistry.Nucleotides;
using FluentAssertions;
using NUnit.Framework;

namespace PSLibrary.Tests
{

    [TestFixture()]
    public class CellTests
    {
        private readonly string _genomePhiX174Virus = "ATGCGACCTTGGGCAAG";

        [Test()]
        public void CreateCellTest()
        {
            List<Nucleotide> strand = [];
            strand.FillFromString(_genomePhiX174Virus);
            Cell.EnergyUnits = _genomePhiX174Virus.Length;
            var cell = new Cell(strand);

            var dna = cell.CellDNA;
            dna.FirstStrand.Count.Should().Be(dna.SecondStrand.Count);
            dna.FirstStrand.First().Should().BeOfType<Adenine>();
            dna.SecondStrand.First().Should().BeOfType<Thymine>();
        }

        [Test()]
        public void SplitTest()
        {
            var cell = new Cell(_genomePhiX174Virus);
            cell.FeedOn(_genomePhiX174Virus.Length * 2);
            var newCell = cell.Split();

            cell.CellDNA.FirstStrand.Should().BeEquivalentTo(newCell.CellDNA.SecondStrand);
            cell.CellDNA.SecondStrand.Should().BeEquivalentTo(newCell.CellDNA.FirstStrand);
        }

        [Test()]
        public void TranscriptTest()
        {
            //Arrange
            const string genome = "Т–А–Т–А–Ц–Ц–Г–А–А";
            Cell cell = new Cell(genome);

            //Act
            cell.Transcript();

            //Assert
            cell.CellDNA.FirstStrand.Count.Should().Be(cell.CellRNA.Strand.Count);
            cell.CellDNA.FirstStrand.First().Should().BeOfType<Thymine>();
            cell.CellRNA.Strand.First().Should().BeOfType<Adenine>();

        }

        [Test()]
        public void TranslateTest()
        {
            string expected = "Proline-Cysteine-Methionine";
            Cell cell = new Cell("Г–Г–Г–А–Ц–А–Т–А–Ц");
            cell.Transcript();
            cell.Translate();

            var result = cell.GetProteins();
            result.Should().Be(expected);
        }

        [Test()]
        public void GetProteinsTest()
        {
            var expected = "Valine-Phenylalanine-Cysteine";
            var genome = "ЦАЦ–ААГ–АЦГ";
            var cell = new Cell(genome);
            cell.Transcript();
            cell.Translate();
            var proteins = cell.GetProteins();

            proteins.Should().Be(expected);
        }
    }
}