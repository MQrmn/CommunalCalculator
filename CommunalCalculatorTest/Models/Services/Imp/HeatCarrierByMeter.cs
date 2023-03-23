namespace Core
{
    internal class HeatCarrierByMeter : CommunalServiceByMeter
    {
        public HeatCarrierByMeter(decimal scopeOfService) : base(scopeOfService) 
        {
            Type = Enums.ServiceTypes.HeatCarrier;
        }
        public HeatCarrierByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) 
        {
            Type = Enums.ServiceTypes.HeatCarrier;
        }
    
    }
}
