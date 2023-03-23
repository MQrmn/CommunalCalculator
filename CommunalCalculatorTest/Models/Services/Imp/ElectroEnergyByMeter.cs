namespace Core
{
    internal class ElectroEnergyByMeter : CommunalServiceByMeter
    {
        public ElectroEnergyByMeter(decimal scopeOfService) : base(scopeOfService) 
        { 
            Type = Enums.ServiceTypes.ElectroEnergyCommon; 
        }
        public ElectroEnergyByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) 
        { 
            Type = Enums.ServiceTypes.ElectroEnergyCommon; 
        }
    }
}
