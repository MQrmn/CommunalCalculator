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
            this.Cost = Math.Round( this.VolumeOfServices * this.Rate.Cost, 2);
            return this.Cost;
        }
    }
}
