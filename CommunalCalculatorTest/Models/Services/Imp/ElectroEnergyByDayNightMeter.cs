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
        }
        internal override double GetSalary()
        {
            return _day.GetSalary() + _night.GetSalary();
        }
    }
}
