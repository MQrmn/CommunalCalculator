namespace Core
{
    internal class HeatCarrierByMeter : CommunalServiceByMeter
    {
        public HeatCarrierByMeter(decimal previousValue, decimal currentValue) : base(previousValue, currentValue) 
        {
            ServiceType = (int)Enums.ServiceTypes.HeatCarrier;
        }
    
    }
}
