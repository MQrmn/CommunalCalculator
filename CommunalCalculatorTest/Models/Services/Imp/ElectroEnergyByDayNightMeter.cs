namespace Core
{
    internal class ElectroEnergyByDayNightMeter : CommunalService
    {
        internal CommunalService _day { get; set; }
        internal CommunalService _night { get; set; }
        public ElectroEnergyByDayNightMeter(CommunalService day, CommunalService night)
        {
            _day = day;
            _night = night;
            Type = Enums.ServiceTypes.ElectroEnergyCommon;
        }
        internal override decimal GetSalary()
        {
            return _day.GetSalary() + _night.GetSalary();
        }
    }
}
