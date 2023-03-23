namespace Core
{
    internal class ThermalEnergyByMeter : CommunalServiceByMeter
    {
        public ThermalEnergyByMeter(decimal scopeOfService) : base(scopeOfService) 
        {
            Type = Enums.ServiceTypes.ThermalEnergy;
        }

        internal override decimal GetSalary()
        {
            return this._serviceVolume * this.Rate.Normative * this.Rate.Cost;
        }
    }
}
