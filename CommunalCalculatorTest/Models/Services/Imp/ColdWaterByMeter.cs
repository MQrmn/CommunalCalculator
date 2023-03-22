namespace Core
{
    internal class ColdWaterByMeter : CommunalServiceByMeter
    {
        public ColdWaterByMeter(int scopeOfService) : base(scopeOfService) { }
        public ColdWaterByMeter(int readingBefore, int readingNow) : base(readingBefore, readingNow) { }
    }
}
