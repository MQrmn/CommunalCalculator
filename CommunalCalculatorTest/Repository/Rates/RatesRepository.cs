namespace Core
{
    internal class RatesRepository : IRatesRepository
    {
        public CommunalRate GetColdWater()
        {
            return new CommunalRate() { Rate = 35.78m, Normative = 4.85m };
        }

        public CommunalRate GetElectroEnergyCommon()
        {
            return new CommunalRate() { Rate = 4.28m, Normative = 164m };
        }

        public CommunalRate GetElectroEnergyDay()
        {
            return new CommunalRate() { Rate = 4.9m };
        }

        public CommunalRate GetElectroEnergyNight()
        {
            return new CommunalRate() { Rate = 2.31m };
        }

        public CommunalRate GetHeatCarrierRate()
        {
            return new CommunalRate() { Rate = 35.78m, Normative = 4.01m };
        }

        public CommunalRate GetThermalEnergy()
        {
            return new CommunalRate() { Rate = 998.69m, Normative = 0.05349m };
        }
    }
}
