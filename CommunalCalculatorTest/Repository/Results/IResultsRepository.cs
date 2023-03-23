namespace Core
{
    public interface IResultsRepository
    {
        public void Addresult(ServiceResult result);
        public List<ServiceResult> GetResultsByServiceType(Enums.ServiceTypes type);
        public bool CheckIsresultsByServiceType(Enums.ServiceTypes type);
    }
}
