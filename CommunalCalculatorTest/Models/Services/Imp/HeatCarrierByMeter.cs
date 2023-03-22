namespace Core
{
    internal class HeatCarrierByMeter : CommunalServiceByMeter
    {
        public HeatCarrierByMeter(decimal scopeOfService) : base(scopeOfService) { }
        public HeatCarrierByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) { }
    
    }
}
