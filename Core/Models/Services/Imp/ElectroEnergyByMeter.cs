namespace Core
{
    internal class ElectroEnergyByMeter : CommunalServiceByMeter
    {
        public ElectroEnergyByMeter(decimal previousValue, decimal currentValue) : base(previousValue, currentValue) 
        { 
            ServiceType = (int)Enums.ServiceTypes.ElectroEnergyCommon; 
        }
    }
}


