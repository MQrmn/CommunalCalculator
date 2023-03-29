namespace Core
{
    internal class ThermalEnergyByNormative : CommunalServiceByNormative
    {
        public CommunalRate HeatCarrierRate { get; set; }
        public ThermalEnergyByNormative(int residentsCount) : base(residentsCount)
        {
            ServiceType = (int)Enums.ServiceTypes.ThermalEnergy;
        }

        internal override void Calculate()
        {
            this.VolumeOfServices = this.ResidentsCount * this.HeatCarrierRate.Normative * this.Rate.Normative;
            this.Cost = Math.Round(this.VolumeOfServices * this.Rate.Cost, 2);
        }
    }
}
