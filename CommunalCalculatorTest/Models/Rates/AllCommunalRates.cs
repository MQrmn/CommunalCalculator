namespace Core
{
    internal class AllCommunalRates
    {
        internal CommunalRate ColdWater { get; set; }
        internal CommunalRate ElectroEnergy { get; set; }
        internal CommunalRate HeatCarrier { get; set; }
        internal CommunalRate ThermalEnergy { get; set; }
        public AllCommunalRates()
        {
            ColdWater = new ColdWaterRate();
            ElectroEnergy= new ElectroEnergyRate();
            HeatCarrier = new HeatCarrierRate();
            ThermalEnergy= new ThermalEnergyRate();
        }
    }
}
