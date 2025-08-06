using Alexon.Chemistry.Elements.Base;

namespace Alexon.Chemistry.Elements
{
    public class Hydrogen : Atom
    {
        public override int AtomicNumber => 1;
        public override string Symbol => "H";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 0;
        public override double MassDefectPerNucleonAmu => 0.0000; // Hydrogen has no mass defect
    }
    public class Helium : Atom
    {
        public override int AtomicNumber => 2;
        public override string Symbol => "He";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 2;
        public override double MassDefectPerNucleonAmu => 0.00257; // Helium has a small mass defect
    }
    public class Lithium : Atom
    {
        public override int AtomicNumber => 3;
        public override string Symbol => "Li";
        public override ElementGroups Group => ElementGroups.AlkaliMetal;
        public override int CommonIsotopeNeutrons => 4;
        public override double MassDefectPerNucleonAmu => 0.00234; // Lithium has a small mass defect
    }
    public class Beryllium : Atom
    {
        public override int AtomicNumber => 4;
        public override string Symbol => "Be";
        public override ElementGroups Group => ElementGroups.AlkalineEarthMetal;
        public override int CommonIsotopeNeutrons => 5;
        public override double MassDefectPerNucleonAmu => 0.00147; // Beryllium has a small mass defect
    }
    public class Boron : Atom
    {
        public override int AtomicNumber => 5;
        public override string Symbol => "B";
        public override ElementGroups Group => ElementGroups.Metalloid;
        public override int CommonIsotopeNeutrons => 6;
        public override double MassDefectPerNucleonAmu => 0.00120; 
    }
    public class Carbon : Atom
    {
        public override int AtomicNumber => 6;
        public override string Symbol => "C";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 6;
        public override double MassDefectPerNucleonAmu => 0.00766;
    }
    public class Nitrogen : Atom
    {
        public override int AtomicNumber => 7;
        public override string Symbol => "N";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 7;
        public override double MassDefectPerNucleonAmu => 0.00105; // Nitrogen has a small mass defect
    }
    public class Oxygen : Atom
    {
        public override int AtomicNumber => 8;
        public override string Symbol => "O";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 8;
        public override double MassDefectPerNucleonAmu => 0.008562836;
    }
    public class Fluorine : Atom
    {
        public override int AtomicNumber => 9;
        public override string Symbol => "F";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 10;
        public override double MassDefectPerNucleonAmu => 0.00092; // Fluorine has a small mass defect
    }
    public class Neon : Atom
    {
        public override int AtomicNumber => 10;
        public override string Symbol => "Ne";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 10;
        public override double MassDefectPerNucleonAmu => 0.00087; // Neon has a small mass defect
    }
    public class Sodium : Atom
    {
        public override int AtomicNumber => 11;
        public override string Symbol => "Na";
        public override ElementGroups Group => ElementGroups.AlkaliMetal;
        public override int CommonIsotopeNeutrons => 12;
        public override double MassDefectPerNucleonAmu => 0.00832; // Sodium has a small mass defect
    }
    public class Magnesium : Atom
    {
        public override int AtomicNumber => 12;
        public override string Symbol => "Mg";
        public override ElementGroups Group => ElementGroups.AlkalineEarthMetal;
        public override int CommonIsotopeNeutrons => 12;
        public override double MassDefectPerNucleonAmu => 0.00784; // Magnesium has a small mass defect
    }
    public class Aluminium : Atom
    {
        public override int AtomicNumber => 13;
        public override string Symbol => "Al";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 14;
        public override double MassDefectPerNucleonAmu => 0.00720; // Aluminium has a small mass defect
    }
    public class Silicon : Atom
    {
        public override int AtomicNumber => 14;
        public override string Symbol => "Si";
        public override ElementGroups Group => ElementGroups.Metalloid;
        public override int CommonIsotopeNeutrons => 14;
        public override double MassDefectPerNucleonAmu => 0.00670; // Silicon has a small mass defect
    }
    public class Phosphorus : Atom
    {
        public override int AtomicNumber => 15;
        public override string Symbol => "P";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 16;
        public override double MassDefectPerNucleonAmu => 0.00620; // Phosphorus has a small mass defect
    }
    public class Sulfur : Atom
    {
        public override int AtomicNumber => 16;
        public override string Symbol => "S";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 16;
        public override double MassDefectPerNucleonAmu => 0.00580; // Sulfur has a small mass defect
    }
    public class Chlorine : Atom
    {
        public override int AtomicNumber => 17;
        public override string Symbol => "Cl";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 18;
        public override double MassDefectPerNucleonAmu => 0.00540; // Chlorine has a small mass defect
    }
    public class Argon : Atom
    {
        public override int AtomicNumber => 18;
        public override string Symbol => "Ar";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 22;
        public override double MassDefectPerNucleonAmu => 0.00500; // Argon has a small mass defect
    }
    public class Potassium : Atom
    {
        public override int AtomicNumber => 19;
        public override string Symbol => "K";
        public override ElementGroups Group => ElementGroups.AlkaliMetal;
        public override int CommonIsotopeNeutrons => 20;
        public override double MassDefectPerNucleonAmu => 0.00460; // Potassium has a small mass defect
    }
    public class Calcium : Atom
    {
        public override int AtomicNumber => 20;
        public override string Symbol => "Ca";
        public override ElementGroups Group => ElementGroups.AlkalineEarthMetal;
        public override int CommonIsotopeNeutrons => 20;
        public override double MassDefectPerNucleonAmu => 0.00420; // Calcium has a small mass defect
    }
    public class Scandium : Atom
    {
        public override int AtomicNumber => 21;
        public override string Symbol => "Sc";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 24;
        public override double MassDefectPerNucleonAmu => 0.00380; // Scandium has a small mass defect
    }
    public class Titanium : Atom
    {
        public override int AtomicNumber => 22;
        public override string Symbol => "Ti";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 26;
        public override double MassDefectPerNucleonAmu => 0.00350; // Titanium has a small mass defect
    }
    public class Vanadium : Atom
    {
        public override int AtomicNumber => 23;
        public override string Symbol => "V";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 28;
        public override double MassDefectPerNucleonAmu => 0.00320; // Vanadium has a small mass defect
    }
    public class Chromium : Atom
    {
        public override int AtomicNumber => 24;
        public override string Symbol => "Cr";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 28;
        public override double MassDefectPerNucleonAmu => 0.00290; // Chromium has a small mass defect
    }
    public class Manganese : Atom
    {
        public override int AtomicNumber => 25;
        public override string Symbol => "Mn";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 30;
        public override double MassDefectPerNucleonAmu => 0.00260; // Manganese has a small mass defect
    }
    public class Iron : Atom
    {
        public override int AtomicNumber => 26;
        public override string Symbol => "Fe";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 30;
        public override double MassDefectPerNucleonAmu => 0.00230; // Iron has a small mass defect
    }
    public class Cobalt : Atom
    {
        public override int AtomicNumber => 27;
        public override string Symbol => "Co";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 32;
        public override double MassDefectPerNucleonAmu => 0.00200; // Cobalt has a small mass defect
    }
    public class Nickel : Atom
    {
        public override int AtomicNumber => 28;
        public override string Symbol => "Ni";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 31;
        public override double MassDefectPerNucleonAmu => 0.00170; // Nickel has a small mass defect
    }
    public class Copper : Atom
    {
        public override int AtomicNumber => 29;
        public override string Symbol => "Cu";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 35;
        public override double MassDefectPerNucleonAmu => 0.00140; // Copper has a small mass defect
    }
    public class Zinc : Atom
    {
        public override int AtomicNumber => 30;
        public override string Symbol => "Zn";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 35;
        public override double MassDefectPerNucleonAmu => 0.00110; // Zinc has a small mass defect
    }
    public class Gallium : Atom
    {
        public override int AtomicNumber => 31;
        public override string Symbol => "Ga";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 39;
        public override double MassDefectPerNucleonAmu => 0.00080; // Gallium has a small mass defect
    }
    public class Germanium : Atom
    {
        public override int AtomicNumber => 32;
        public override string Symbol => "Ge";
        public override ElementGroups Group => ElementGroups.Metalloid;
        public override int CommonIsotopeNeutrons => 41;
        public override double MassDefectPerNucleonAmu => 0.00050; // Germanium has a small mass defect
    }
    public class Arsenic : Atom
    {
        public override int AtomicNumber => 33;
        public override string Symbol => "As";
        public override ElementGroups Group => ElementGroups.Metalloid;
        public override int CommonIsotopeNeutrons => 42;
        public override double MassDefectPerNucleonAmu => 0.00020; // Arsenic has a small mass defect
    }
    public class Selenium : Atom
    {
        public override int AtomicNumber => 34;
        public override string Symbol => "Se";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 45;
        public override double MassDefectPerNucleonAmu => 0.00010; // Selenium has a small mass defect
    }
    public class Bromine : Atom
    {
        public override int AtomicNumber => 35;
        public override string Symbol => "Br";
        public override ElementGroups Group => ElementGroups.Halogen;
        public override int CommonIsotopeNeutrons => 45;
        public override double MassDefectPerNucleonAmu => 0.00005; // Bromine has a small mass defect
    }
    public class Krypton : Atom
    {
        public override int AtomicNumber => 36;
        public override string Symbol => "Kr";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 48;
        public override double MassDefectPerNucleonAmu => 0.00002; // Krypton has a small mass defect
    }
    public class Rubidium : Atom
    {
        public override int AtomicNumber => 37;
        public override string Symbol => "Rb";
        public override ElementGroups Group => ElementGroups.AlkaliMetal;
        public override int CommonIsotopeNeutrons => 48;
        public override double MassDefectPerNucleonAmu => 0.00001; // Rubidium has a small mass defect
    }
    public class Strontium : Atom
    {
        public override int AtomicNumber => 38;
        public override string Symbol => "Sr";
        public override ElementGroups Group => ElementGroups.AlkalineEarthMetal;
        public override int CommonIsotopeNeutrons => 50;
        public override double MassDefectPerNucleonAmu => 0.000005; // Strontium has a small mass defect
    }
    public class Yttrium : Atom
    {
        public override int AtomicNumber => 39;
        public override string Symbol => "Y";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 50;
        public override double MassDefectPerNucleonAmu => 0.000002; // Yttrium has a small mass defect
    }
    public class Zirconium : Atom
    {
        public override int AtomicNumber => 40;
        public override string Symbol => "Zr";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 51;
        public override double MassDefectPerNucleonAmu => 0.000001; // Zirconium has a small mass defect
    }
    public class Niobium : Atom
    {
        public override int AtomicNumber => 41;
        public override string Symbol => "Nb";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 52;
        public override double MassDefectPerNucleonAmu => 0.0000005; // Niobium has a small mass defect
    }
    public class Molybdenum : Atom
    {
        public override int AtomicNumber => 42;
        public override string Symbol => "Mo";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 54;
        public override double MassDefectPerNucleonAmu => 0.0000002; // Molybdenum has a small mass defect
    }
    public class Technetium : Atom
    {
        public override int AtomicNumber => 43;
        public override string Symbol => "Tc";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 55;
        public override double MassDefectPerNucleonAmu => 0.0000001; // Technetium has a small mass defect
    }
    public class Ruthenium : Atom
    {
        public override int AtomicNumber => 44;
        public override string Symbol => "Ru";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 57;
        public override double MassDefectPerNucleonAmu => 0.00000005; // Ruthenium has a small mass defect
    }
    public class Rhodium : Atom
    {
        public override int AtomicNumber => 45;
        public override string Symbol => "Rh";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 58;
        public override double MassDefectPerNucleonAmu => 0.00000002; // Rhodium has a small mass defect
    }
    public class Palladium : Atom
    {
        public override int AtomicNumber => 46;
        public override string Symbol => "Pd";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 60;
        public override double MassDefectPerNucleonAmu => 0.00000001; // Palladium has a small mass defect
    }
    public class Silver : Atom
    {
        public override int AtomicNumber => 47;
        public override string Symbol => "Ag";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 61;
        public override double MassDefectPerNucleonAmu => 0.000000005; // Silver has a small mass defect
    }
    public class Cadmium : Atom
    {
        public override int AtomicNumber => 48;
        public override string Symbol => "Cd";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 64;
        public override double MassDefectPerNucleonAmu => 0.000000002; // Cadmium has a small mass defect
    }
    public class Indium : Atom
    {
        public override int AtomicNumber => 49;
        public override string Symbol => "In";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 66;
        public override double MassDefectPerNucleonAmu => 0.000000001; // Indium has a small mass defect
    }
    public class Tin : Atom
    {
        public override int AtomicNumber => 50;
        public override string Symbol => "Sn";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 69;
        public override double MassDefectPerNucleonAmu => 0.0000000005; // Tin has a small mass defect
    }
    public class Antimony : Atom
    {
        public override int AtomicNumber => 51;
        public override string Symbol => "Sb";
        public override ElementGroups Group => ElementGroups.Metalloid;
        public override int CommonIsotopeNeutrons => 71;
        public override double MassDefectPerNucleonAmu => 0.0000000002; // Antimony has a small mass defect
    }
    public class Tellurium : Atom
    {
        public override int AtomicNumber => 52;
        public override string Symbol => "Te";
        public override ElementGroups Group => ElementGroups.NonMetal;
        public override int CommonIsotopeNeutrons => 76;
        public override double MassDefectPerNucleonAmu => 0.0000000001; // Tellurium has a small mass defect
    }
    public class Iodine : Atom
    {
        public override int AtomicNumber => 53;
        public override string Symbol => "I";
        public override ElementGroups Group => ElementGroups.Halogen;
        public override int CommonIsotopeNeutrons => 74;
        public override double MassDefectPerNucleonAmu => 0.00000000005; // Iodine has a small mass defect
    }
    public class Xenon : Atom
    {
        public override int AtomicNumber => 54;
        public override string Symbol => "Xe";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 77;
        public override double MassDefectPerNucleonAmu => 0.00000000002; // Xenon has a small mass defect
    }
    public class Cesium : Atom
    {
        public override int AtomicNumber => 55;
        public override string Symbol => "Cs";
        public override ElementGroups Group => ElementGroups.AlkaliMetal;
        public override int CommonIsotopeNeutrons => 78;
        public override double MassDefectPerNucleonAmu => 0.00000000001; // Cesium has a small mass defect
    }
    public class Barium : Atom
    {
        public override int AtomicNumber => 56;
        public override string Symbol => "Ba";
        public override ElementGroups Group => ElementGroups.AlkalineEarthMetal;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.000000000005; // Barium has a small mass defect
    }
    public class Lanthanum : Atom
    {
        public override int AtomicNumber => 57;
        public override string Symbol => "La";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.000000000002; // Lanthanum has a small mass defect
    }
    public class Cerium : Atom
    {
        public override int AtomicNumber => 58;
        public override string Symbol => "Ce";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.000000000001; // Cerium has a small mass defect
    }
    public class Praseodymium : Atom
    {
        public override int AtomicNumber => 59;
        public override string Symbol => "Pr";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.0000000000005; // Praseodymium has a small mass defect
    }
    public class Neodymium : Atom
    {
        public override int AtomicNumber => 60;
        public override string Symbol => "Nd";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.0000000000002; // Neodymium has a small mass defect
    }
    public class Promethium : Atom
    {
        public override int AtomicNumber => 61;
        public override string Symbol => "Pm";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.0000000000001; // Promethium has a small mass defect
    }
    public class Samarium : Atom
    {
        public override int AtomicNumber => 62;
        public override string Symbol => "Sm";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.00000000000005; // Samarium has a small mass defect
    }
    public class Europium : Atom
    {
        public override int AtomicNumber => 63;
        public override string Symbol => "Eu";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.00000000000002; // Europium has a small mass defect
    }
    public class Gadolinium : Atom
    {
        public override int AtomicNumber => 64;
        public override string Symbol => "Gd";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.00000000000001; // Gadolinium has a small mass defect
    }
    public class Terbium : Atom
    {
        public override int AtomicNumber => 65;
        public override string Symbol => "Tb";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.000000000000005; // Terbium has a small mass defect
    }
    public class Dysprosium : Atom
    {
        public override int AtomicNumber => 66;
        public override string Symbol => "Dy";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.000000000000002; // Dysprosium has a small mass defect
    }
    public class Holmium : Atom
    {
        public override int AtomicNumber => 67;
        public override string Symbol => "Ho";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.000000000000001; // Holmium has a small mass defect
    }
    public class Erbium : Atom
    {
        public override int AtomicNumber => 68;
        public override string Symbol => "Er";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.0000000000000005; // Erbium has a small mass defect
    }
    public class Thulium : Atom
    {
        public override int AtomicNumber => 69;
        public override string Symbol => "Tm";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.0000000000000002; // Thulium has a small mass defect
    }
    public class Ytterbium : Atom
    {
        public override int AtomicNumber => 70;
        public override string Symbol => "Yb";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.0000000000000001; // Ytterbium has a small mass defect
    }
    public class Lutetium : Atom
    {
        public override int AtomicNumber => 71;
        public override string Symbol => "Lu";
        public override ElementGroups Group => ElementGroups.Lanthanide;
        public override int CommonIsotopeNeutrons => 82;
        public override double MassDefectPerNucleonAmu => 0.00000000000000005; // Lutetium has a small mass defect
    }
    public class Hafnium : Atom
    {
        public override int AtomicNumber => 72;
        public override string Symbol => "Hf";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 106;
        public override double MassDefectPerNucleonAmu => 0.00000000000000002; // Hafnium has a small mass defect
    }
    public class Tantalum : Atom
    {
        public override int AtomicNumber => 73;
        public override string Symbol => "Ta";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 108;
        public override double MassDefectPerNucleonAmu => 0.00000000000000001; // Tantalum has a small mass defect
    }
    public class Tungsten : Atom
    {
        public override int AtomicNumber => 74;
        public override string Symbol => "W";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 110;
        public override double MassDefectPerNucleonAmu => 0.000000000000000005; // Tungsten has a small mass defect
    }
    public class Rhenium : Atom
    {
        public override int AtomicNumber => 75;
        public override string Symbol => "Re";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 111;
        public override double MassDefectPerNucleonAmu => 0.000000000000000002; // Rhenium has a small mass defect
    }
    public class Osmium : Atom
    {
        public override int AtomicNumber => 76;
        public override string Symbol => "Os";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 114;
        public override double MassDefectPerNucleonAmu => 0.000000000000000001; // Osmium has a small mass defect
    }
    public class Iridium : Atom
    {
        public override int AtomicNumber => 77;
        public override string Symbol => "Ir";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 115;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000005; // Iridium has a small mass defect
    }
    public class Platinum : Atom
    {
        public override int AtomicNumber => 78;
        public override string Symbol => "Pt";
        public override ElementGroups Group => ElementGroups.TransitionMetal;
        public override int CommonIsotopeNeutrons => 117;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000002; // Platinum has a small mass defect
    }
    public class Gold : Atom
    {
        public override int AtomicNumber => 79;
        public override string Symbol => "Au";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 118;
        public override double MassDefectPerNucleonAmu => 0.00802;
    }
    public class Mercury : Atom
    {
        public override int AtomicNumber => 80;
        public override string Symbol => "Hg";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 121;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000005; // Mercury has a small mass defect
    }
    public class Thallium : Atom
    {
        public override int AtomicNumber => 81;
        public override string Symbol => "Tl";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 126;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000002; // Thallium has a small mass defect
    }
    public class Lead : Atom
    {
        public override int AtomicNumber => 82;
        public override string Symbol => "Pb";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 125;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000001; // Lead has a small mass defect
    }
    public class Bismuth : Atom
    {
        public override int AtomicNumber => 83;
        public override string Symbol => "Bi";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 126;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000005; // Bismuth has a small mass defect
    }
    public class Polonium : Atom
    {
        public override int AtomicNumber => 84;
        public override string Symbol => "Po";
        public override ElementGroups Group => ElementGroups.PostTransitionMetal;
        public override int CommonIsotopeNeutrons => 125;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000002; // Polonium has a small mass defect
    }
    public class Astatine : Atom
    {
        public override int AtomicNumber => 85;
        public override string Symbol => "At";
        public override ElementGroups Group => ElementGroups.Halogen;
        public override int CommonIsotopeNeutrons => 125;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000001; // Astatine has a small mass defect
    }
    public class Radon : Atom
    {
        public override int AtomicNumber => 86;
        public override string Symbol => "Rn";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 136;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000005; // Radon has a small mass defect
    }
    public class Francium : Atom
    {
        public override int AtomicNumber => 87;
        public override string Symbol => "Fr";
        public override ElementGroups Group => ElementGroups.AlkaliMetal;
        public override int CommonIsotopeNeutrons => 136;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000002; // Francium has a small mass defect
    }
    public class Radium : Atom
    {
        public override int AtomicNumber => 88;
        public override string Symbol => "Ra";
        public override ElementGroups Group => ElementGroups.AlkalineEarthMetal;
        public override int CommonIsotopeNeutrons => 138;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000001; // Radium has a small mass defect
    }
    public class Actinium : Atom
    {
        public override int AtomicNumber => 89;
        public override string Symbol => "Ac";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 138;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000005; // Actinium has a small mass defect
    }
    public class Thorium : Atom
    {
        public override int AtomicNumber => 90;
        public override string Symbol => "Th";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 142;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000002; // Thorium has a small mass defect
    }
    public class Protactinium : Atom
    {
        public override int AtomicNumber => 91;
        public override string Symbol => "Pa";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 141;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000001; // Protactinium has a small mass defect
    }
    public class Uranium : Atom
    {
        public override int AtomicNumber => 92;
        public override string Symbol => "U";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 146;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000005; // Uranium has a small mass defect
    }
    public class Neptunium : Atom
    {
        public override int AtomicNumber => 93;
        public override string Symbol => "Np";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 144;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000002; // Neptunium has a small mass defect
    }
    public class Plutonium : Atom
    {
        public override int AtomicNumber => 94;
        public override string Symbol => "Pu";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 150;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000001; // Plutonium has a small mass defect
    }
    public class Americium : Atom
    {
        public override int AtomicNumber => 95;
        public override string Symbol => "Am";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 148;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000000005; // Americium has a small mass defect
    }
    public class Curium : Atom
    {
        public override int AtomicNumber => 96;
        public override string Symbol => "Cm";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 151;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000000002; // Curium has a small mass defect
    }

    public class Berkelium : Atom
    {
        public override int AtomicNumber => 97;
        public override string Symbol => "Bk";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 150;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000000001; // Berkelium has a small mass defect
    }
    public class Californium : Atom
    {
        public override int AtomicNumber => 98;
        public override string Symbol => "Cf";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 153;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000000005; // Californium has a small mass defect
    }
    public class Einsteinium : Atom
    {
        public override int AtomicNumber => 99;
        public override string Symbol => "Es";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 153;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000000002; // Einsteinium has a small mass defect
    }
    public class Fermium : Atom
    {
        public override int AtomicNumber => 100;
        public override string Symbol => "Fm";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 157;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000000001; // Fermium has a small mass defect
    }
    public class Mendelevium : Atom
    {
        public override int AtomicNumber => 101;
        public override string Symbol => "Md";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 158;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000000005; // Mendelevium has a small mass defect
    }
    public class Nobelium : Atom
    {
        public override int AtomicNumber => 102;
        public override string Symbol => "No";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 157;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000000002; // Nobelium has a small mass defect
    }
    public class Lawrencium : Atom
    {
        public override int AtomicNumber => 103;
        public override string Symbol => "Lr";
        public override ElementGroups Group => ElementGroups.Actinide;
        public override int CommonIsotopeNeutrons => 162;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000000001; // Lawrencium has a small mass defect
    }
    public class Rutherfordium : Atom
    {
        public override int AtomicNumber => 104;
        public override string Symbol => "Rf";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 157;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000000000005; // Rutherfordium has a small mass defect
    }
    public class Dubnium : Atom
    {
        public override int AtomicNumber => 105;
        public override string Symbol => "Db";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 159;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000000000002; // Dubnium has a small mass defect
    }
    public class Seaborgium : Atom
    {
        public override int AtomicNumber => 106;
        public override string Symbol => "Sg";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 163;
        public override double MassDefectPerNucleonAmu => 0.0000000000000000000000000001; // Seaborgium has a small mass defect
    }
    public class Bohrium : Atom
    {
        public override int AtomicNumber => 107;
        public override string Symbol => "Bh";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 162;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000000000005; // Bohrium has a small mass defect
    }
    public class Hassium : Atom
    {
        public override int AtomicNumber => 108;
        public override string Symbol => "Hs";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 165;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000000000002; // Hassium has a small mass defect
    }
    public class Meitnerium : Atom
    {
        public override int AtomicNumber => 109;
        public override string Symbol => "Mt";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 166;
        public override double MassDefectPerNucleonAmu => 0.00000000000000000000000000001; // Meitnerium has a small mass defect
    }
    public class Darmstadtium : Atom
    {
        public override int AtomicNumber => 110;
        public override string Symbol => "Ds";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 171;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000000000005; // Darmstadtium has a small mass defect
    }
    public class Roentgenium : Atom
    {
        public override int AtomicNumber => 111;
        public override string Symbol => "Rg";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 173;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000000000002; // Roentgenium has a small mass defect
    }
    public class Copernicium : Atom
    {
        public override int AtomicNumber => 112;
        public override string Symbol => "Cn";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 175;
        public override double MassDefectPerNucleonAmu => 0.000000000000000000000000000001; // Copernicium has a small mass defect
    }
    public class Nihonium : Atom
    {
        public override int AtomicNumber => 113;
        public override string Symbol => "Nh";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 176;
        public override double MassDefectPerNucleonAmu => 0.00734;
    }
    public class Flerovium : Atom
    {
        public override int AtomicNumber => 114;
        public override string Symbol => "Fl";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 175;
        public override double MassDefectPerNucleonAmu => 0.00734; // Flerovium has a small mass defect
    }
    public class Moscovium : Atom
    {
        public override int AtomicNumber => 115;
        public override string Symbol => "Mc";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 177;
        public override double MassDefectPerNucleonAmu => 0.00734; // Moscovium has a small mass defect
    }
    public class Livermorium : Atom
    {
        public override int AtomicNumber => 116;
        public override string Symbol => "Lv";
        public override ElementGroups Group => ElementGroups.Transactinide;
        public override int CommonIsotopeNeutrons => 177;
        public override double MassDefectPerNucleonAmu => 0.00734; // Livermorium has a small mass defect
    }
    public class Tennessine : Atom
    {
        public override int AtomicNumber => 117;
        public override string Symbol => "Ts";
        public override ElementGroups Group => ElementGroups.Halogen;
        public override int CommonIsotopeNeutrons => 177;
        public override double MassDefectPerNucleonAmu => 0.00734; // Tennessine has a small mass defect
    }
    public class Oganesson : Atom
    {
        public override int AtomicNumber => 118;
        public override string Symbol => "Og";
        public override ElementGroups Group => ElementGroups.NobleGas;
        public override int CommonIsotopeNeutrons => 177;
        public override double MassDefectPerNucleonAmu => 0.00734; // Oganesson has a small mass defect
    }
}