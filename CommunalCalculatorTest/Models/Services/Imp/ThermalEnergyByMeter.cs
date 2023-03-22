namespace Core
{
    internal class ThermalEnergyByMeter : CommunalServiceByMeter
    {
        public ThermalEnergyByMeter(decimal scopeOfService) : base(scopeOfService) { }
        public ThermalEnergyByMeter(decimal readingBefore, decimal readingNow) : base(readingBefore, readingNow) { }
        internal override decimal GetSalary()
        {
            return this._scopeOfServices * this.Rate.Normative * this.Rate.Rate;
        }
    }
}
