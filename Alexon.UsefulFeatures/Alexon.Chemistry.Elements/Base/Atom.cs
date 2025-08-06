using Alexon.Chemistry.Elements.Base;

public abstract class Atom
{
    // Абстрактные свойства, которые должны быть переопределены
    public abstract int AtomicNumber { get; }
    public abstract int CommonIsotopeNeutrons { get; }
    public abstract string Symbol { get; }
    public abstract ElementGroups Group { get; }

    // Удельный дефект массы (abstract, так как он уникален для каждого изотопа)
    public abstract double MassDefectPerNucleonAmu { get; }

    // Конструктор
    protected Atom()
    {
        Electrons = AtomicNumber;
    }

    // --- Свойства-расчёты ---

    public int Protons => AtomicNumber;
    public int Neutrons => CommonIsotopeNeutrons;
    public int Electrons { get; set; }
    public int Charge => Protons - Electrons;

    // --- Масса атома ---

    // 1. Теоретическая масса (сумма масс свободных частиц)
    public double TheoreticalAtomicWeightKg
    {
        get
        {
            return (double)Protons * Constants.ProtonMassKg +
                   (double)Neutrons * Constants.NeutronMassKg +
                   (double)Electrons * Constants.ElectronMassKg;
        }
    }

    // 2. Дефект массы (рассчитывается на основе MassDefectPerNucleonAmu)
    public double MassDefectKg
    {
        get
        {
            var totalNucleons = Protons + Neutrons;
            var totalMassDefectAmu = MassDefectPerNucleonAmu * totalNucleons;
            return totalMassDefectAmu * Constants.AtomicMassUnitInKg;
        }
    }

    // 3. Реальная масса (вычитаем дефект массы из теоретической)
    public double RealAtomicWeightKg
    {
        get
        {
            return TheoreticalAtomicWeightKg - MassDefectKg;
        }
    }

    // 4. Относительная атомная масса
    public double RelativeAtomicMass
    {
        get
        {
            return RealAtomicWeightKg / Constants.AtomicMassUnitInKg;
        }
    }
}