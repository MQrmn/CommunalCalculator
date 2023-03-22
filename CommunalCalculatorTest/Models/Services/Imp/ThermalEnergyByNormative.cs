namespace Core
{
    internal class ThermalEnergyByNormative : CommunalServiceByNormative
    {
        public CommunalRate HeatCarrierRate { get; set; }
        public ThermalEnergyByNormative(int residentsCount) : base(residentsCount)
        {
        }

        internal override decimal GetSalary()
        {
            return this.ResidentsCount * HeatCarrierRate.Rate * this.Rate.Normative * this.Rate.Rate;
        }
    }
}
