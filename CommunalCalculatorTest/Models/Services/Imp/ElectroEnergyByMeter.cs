namespace Core
{
    internal class ElectroEnergyByMeter : CommunalServiceByMeter
    {
        public ElectroEnergyByMeter(int scopeOfService) : base(scopeOfService) { }
        public ElectroEnergyByMeter(int readingBefore, int readingNow) : base(readingBefore, readingNow) { }
        internal override double GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
