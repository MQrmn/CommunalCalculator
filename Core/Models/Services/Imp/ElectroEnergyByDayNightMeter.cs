namespace Core
{
    internal class ElectroEnergyByDayNightMeter : CommunalService
    {
        internal CommunalService Day { get; set; }
        internal CommunalService Night { get; set; }
        public ElectroEnergyByDayNightMeter(CommunalService day, CommunalService night)
        {
            Day = day;
            Night = night;
            ServiceType = (int)Enums.ServiceTypes.ElectroEnergyCommon;
            Day.ServiceType = (int)Enums.ServiceTypes.ElectroEnergyDay;
            Night.ServiceType = (int)Enums.ServiceTypes.ElectroEnergyNight;
        }
        internal override void Calculate()
        {
        }
    }
}
