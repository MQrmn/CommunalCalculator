namespace Core
{
    internal interface IMeterValuesRepository
    {
        public void Put();
        public Core.MeterValue GetLastByTypeAndPeriodId(Enums.ServiceTypes type, int id);
        
    }
}
