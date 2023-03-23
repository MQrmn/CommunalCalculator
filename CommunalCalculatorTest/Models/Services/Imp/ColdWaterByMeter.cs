namespace Core
{
    internal class ColdWaterByMeter : CommunalServiceByMeter
    {
        public ColdWaterByMeter(decimal previousValue, decimal currentValue) : base(previousValue, currentValue) 
        {
            Type = Enums.ServiceTypes.ColdWater;
        }
    }
}
