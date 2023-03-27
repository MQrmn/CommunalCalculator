namespace Core
{
    internal interface IRatesRepository
    {
        public CommunalRate GetColdWater();
        public CommunalRate GetElectroEnergyCommon();
        public CommunalRate GetElectroEnergyNight();
        public CommunalRate GetElectroEnergyDay();
        public CommunalRate GetHeatCarrierRate();
        public CommunalRate GetThermalEnergy();
    }
}
