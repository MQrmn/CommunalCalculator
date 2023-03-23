namespace Core
{
    internal class ColdWaterByMeter : CommunalServiceByMeter
    {
        public ColdWaterByMeter(decimal scopeOfService) : base(scopeOfService) 
        {
            Type = Enums.ServiceTypes.ColdWater;
        }
        public ColdWaterByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) 
        {
            Type = Enums.ServiceTypes.ColdWater;
        }
    }
}
