namespace Core
{
    public class AllResults
    {
        public ServiceResult ColdWater { get; set; }
        public ServiceResult ThermalEnergy { get; set; }
        public ServiceResult HeatCarrier { get; set; }
        public ServiceResult ElectroEnergyCommon { get; set; }
        public ServiceResult ElectroEnergyDay { get; set; }
        public ServiceResult ElectroEnergyNight { get; set; }

        public decimal CommonCost { get; set; }

    }
}
