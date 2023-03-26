namespace Core
{
    internal interface IMeterValuesRepository
    {
        public void Put(MeterValue value);
        public Core.MeterValue GetLastByTypeAndPeriodId(Enums.ServiceTypes type, int id);
        public void AddRange(List<ServiceResult> values);

    }
}
