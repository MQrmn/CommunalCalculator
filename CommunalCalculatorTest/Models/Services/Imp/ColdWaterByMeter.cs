namespace Core
{
    internal class ColdWaterByMeter : CommunalServiceByMeter
    {
        public ColdWaterByMeter(decimal scopeOfService) : base(scopeOfService) { }
        public ColdWaterByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) { }
    }
}
