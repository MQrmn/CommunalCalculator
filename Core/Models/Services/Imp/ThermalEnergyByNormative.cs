namespace Core
{
    internal class ThermalEnergyByNormative : CommunalServiceByNormative
    {
        public CommunalRate HeatCarrierRate { get; set; }
        public ThermalEnergyByNormative(int residentsCount) : base(residentsCount)
        {
            ServiceType = (int)Enums.ServiceTypes.ThermalEnergy;
        }

        internal override decimal Calculate()
        {
            this.VolumeOfServices = this.ResidentsCount * this.HeatCarrierRate.Normative;
            this.Cost = Math.Round(this.VolumeOfServices * this.Rate.Normative * this.Rate.Cost, 2);
            return this.Cost;
        }
    }
}
