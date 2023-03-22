namespace Core
{
    internal class ThermalEnergyByMeter : CommunalServiceByMeter
    {
        public ThermalEnergyByMeter(int scopeOfService) : base(scopeOfService) { }
        public ThermalEnergyByMeter(int readingBefore, int readingNow) : base(readingBefore, readingNow) { }
        internal override decimal GetSalary()
        {
            return this._scopeOfServices * this.Rate.Normative * this.Rate.Rate;
        }
    }
}
