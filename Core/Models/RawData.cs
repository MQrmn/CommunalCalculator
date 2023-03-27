namespace Core
{
    public class RawData
    {
        internal BillingPeriod BillingPeriod { get; set; }
        internal CommunalService ColdWater { get; set; }
        internal CommunalService ThermalEnergy { get; set; }
        internal CommunalService HeatCarrier { get; set; }
        internal CommunalService ElectroEnergy { get; set; }
        private int _residentsCount { get; set; }
        internal int ResidentsCount {
            get
            {
                return _residentsCount;
            }
            set
            {
                if (value > 0)
                    _residentsCount = value;
            }
        }

        public void CalculateAll()
        {
            ColdWater.Calculate();
            ThermalEnergy.Calculate();
            HeatCarrier.Calculate();
            ElectroEnergy.Calculate();
        }
    }
}
