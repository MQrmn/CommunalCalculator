namespace Core
{
    internal class ThermalEnergyByMeter : CommunalServiceByMeter
    {
        public ThermalEnergyByMeter(decimal scopeOfService) : base(scopeOfService) 
        {
            Type = Enums.ServiceTypes.ThermalEnergy;
        }
        public ThermalEnergyByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) 
        {
            Type = Enums.ServiceTypes.ThermalEnergy;
        }
        internal override decimal GetSalary()
        {
            return this._scopeOfServices * this.Rate.Normative * this.Rate.Cost;
        }
    }
}
