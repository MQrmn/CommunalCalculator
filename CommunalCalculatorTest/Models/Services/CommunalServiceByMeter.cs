namespace Core
{
    internal abstract class CommunalServiceByMeter : CommunalService
    {
        public decimal PreviousValue { get; set; }
        public decimal CurrentValue { get; set; }
        public CommunalServiceByMeter() { }
        public CommunalServiceByMeter(decimal previousValue, decimal currentValue)
        {
            PreviousValue = previousValue;
            CurrentValue = currentValue;
        }

        internal override decimal Calculate()
        {
            this.VolumeOfServices = CurrentValue - PreviousValue;
            this.Cost =  Rate.Cost * (this.VolumeOfServices);
            return this.Cost;
        }
    }
}
