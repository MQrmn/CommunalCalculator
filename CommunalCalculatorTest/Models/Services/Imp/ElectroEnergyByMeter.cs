namespace Core
{
    internal class ElectroEnergyByMeter : CommunalServiceByMeter
    {
        public ElectroEnergyByMeter(decimal scopeOfService) : base(scopeOfService) { }
        public ElectroEnergyByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) { }
    }
}
