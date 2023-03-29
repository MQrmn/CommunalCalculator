namespace Core
{
    internal interface IMeterValuesRepository
    {
        public void Put(MeterValue value);
        public Core.MeterValue GetByTypeAndPeriodId(Enums.ServiceTypes type, int id);
        public Core.MeterValue GetLastByType(Enums.ServiceTypes type);
        public void AddRange(List<ServiceResult> values);

    }
}
