namespace Core
{
    internal class HeatCarrierByMeter : CommunalServiceByMeter
    {
        public HeatCarrierByMeter(int scopeOfService) : base(scopeOfService) { }
        public HeatCarrierByMeter(int readingBefore, int readingNow) : base(readingBefore, readingNow) { }
        internal override decimal GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
