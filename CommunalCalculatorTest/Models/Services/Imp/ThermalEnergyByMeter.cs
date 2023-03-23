namespace Core
{
    internal class ThermalEnergyByMeter : CommunalServiceByMeter
    {
        public decimal ServiceVolume { get; set; }
        public ThermalEnergyByMeter(decimal serviceVolume) 
        {
            Type = Enums.ServiceTypes.ThermalEnergy;
            ServiceVolume = serviceVolume;
        }

        internal override decimal GetSalary()
        {
            return this.ServiceVolume * this.Rate.Normative * this.Rate.Cost;
        }
    }
}
