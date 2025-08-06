using NUnit.Framework;
using FluentAssertions;
using Alexon.Chemistry.Elements.Base;

namespace Alexon.Chemistry.Elements.Tests
{
    [TestFixture()]
    public class MoleculeTests
    {
        [Test()]
        public void WaterTest()
        {
            var hydrogen = new Hydrogen();
            hydrogen.Electrons.Should().Be(1);
            hydrogen.Protons.Should().Be(1);
            hydrogen.Neutrons.Should().Be(0);
            hydrogen.AtomicNumber.Should().Be(1);
            hydrogen.Symbol.Should().Be("H");
            hydrogen.Group.Should().Be(ElementGroups.NonMetal);
            hydrogen.Charge.Should().Be(0);
            hydrogen.RelativeAtomicMass.Should().BeApproximately(1.007825, precision: 1e-6);//1 007825.031898
            hydrogen.RealAtomicWeightKg.Should().Be(1.6735328620613902E-27);

            var oxygen = new Oxygen();
            oxygen.Electrons.Should().Be(8);
            oxygen.Protons.Should().Be(8);
            oxygen.Neutrons.Should().Be(8);
            oxygen.AtomicNumber.Should().Be(8);
            oxygen.Symbol.Should().Be("O");
            oxygen.Group.Should().Be(ElementGroups.NonMetal);
            oxygen.Charge.Should().Be(0);
            oxygen.RelativeAtomicMass.Should().BeApproximately(15.994914, 1e-6); //15 994914.61926
            oxygen.RealAtomicWeightKg.Should().BeApproximately(2.6561225800000003E-26, 1e-6);

            var water = new Molecule("Water", new List<Atom> { hydrogen, oxygen, hydrogen });
            water.MolecularWeight.Should().BeApproximately(18.010564274211987, 1e-3);

         }
   
        [Test()]
        public void GoldMoleculeTest()
        {
            var gold = new Gold();
            gold.Electrons.Should().Be(79);
            gold.Protons.Should().Be(79);
            gold.Neutrons.Should().Be(118);
            gold.AtomicNumber.Should().Be(79);
            gold.Symbol.Should().Be("Au");
            gold.Group.Should().Be(ElementGroups.PostTransitionMetal);
            gold.Charge.Should().Be(0);
            gold.RelativeAtomicMass.Should().BeApproximately(197.06069848019047, 1e-6);//196 966570.103
            gold.RealAtomicWeightKg.Should().BeApproximately(3.2271504E-25, 1e-6);

        }

        [Test()]   
        public void FormaldehydeMoleculeTest()
        {
            var carbon = new Carbon();
            carbon.RelativeAtomicMass.Should().BeApproximately(12, 1e-2);
            carbon.RealAtomicWeightKg.Should().BeApproximately(1.9926464E-25, 1e-2);
            var hydrogen = new Hydrogen();
            var oxygen = new Oxygen();

            var formula = "CHHO";
            var atoms = formula.ConvertToAtoms();

            var formaldehyde = new Molecule("Formaldehyde", atoms);
            formaldehyde.MolecularWeight.Should().BeApproximately(30.017584149493118, 1e-3);
        }

        [Test()]
        public void EthanolMoleculeTest()
        {
            var carbon = new Carbon();
            var hydrogen = new Hydrogen();
            var oxygen = new Oxygen();
            var formula = "CCHHHHHOH"; // Этиловый спирт (этанол)
            var atoms = formula.ConvertToAtoms();

            var ethanol = new Molecule("Ethanol", atoms);
            ethanol.MolecularWeight.Should().BeApproximately(46.055904087945493, 1e-3);
        }

    }
}