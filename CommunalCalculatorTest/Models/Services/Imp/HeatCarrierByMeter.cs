namespace Core
{
    internal class HeatCarrierByMeter : CommunalServiceByMeter
    {
        public HeatCarrierByMeter(decimal previousValue, decimal currentValue) : base(previousValue, currentValue) 
        {
            Type = Enums.ServiceTypes.HeatCarrier;
        }
    
    }
}
