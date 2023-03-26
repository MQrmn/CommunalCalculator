namespace WebUi
{
    public class CalculateRequestData
    {
        public decimal ColdWaterMeterValue { get; set; }
        public decimal ThermalEnergyMeterValue { get; set; }
        public decimal HeatCarrierMeterValue { get; set; }
        public decimal ElectroEnergyCommonMeterValue { get; set; }
        public decimal ElectroEnergyDayMeterValue { get; set; }
        public decimal ElectroEnergyNightMeterValue { get; set; }
        public int ResidentsCount { get; set; }

    }
}
