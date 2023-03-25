namespace Core
{
    internal class ThermalEnergyByMeter : CommunalServiceByMeter
    {
        public decimal VolumeOfHeatCarrier { get; set; }
        public ThermalEnergyByMeter(decimal serviceVolume) 
        {
            ServiceType = (int)Enums.ServiceTypes.ThermalEnergy;
            this.VolumeOfHeatCarrier = serviceVolume;
        }

        internal override decimal Calculate()
        {
            this.VolumeOfServices = VolumeOfHeatCarrier * this.Rate.Normative;
            this.Cost = this.VolumeOfServices * this.Rate.Cost;
            return this.Cost;
        }
    }
}
