namespace WebUi
{
    public class RequestData
    {
        public decimal ColdWaterMeterValues { get; set; }
        public decimal HotWaterMeterValue { get; set; }
        public decimal ElectroEnergyCommonMeterValue { get; set; }
        public decimal ElectroEnergyDayMeterValue { get; set; }
        public decimal ElectroEnergyNightMeterValue { get; set; }
        public int ResidentsCount { get; set; }

    }
}
