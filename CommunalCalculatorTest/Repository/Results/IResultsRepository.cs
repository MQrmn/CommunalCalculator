namespace Core
{
    internal interface IResultsRepository
    {
        public void Addresult(ResultCommon result);
        public void GetResultsByServiceType(Enums.ServiceTypes type);
        public void CheckIsresultsByServiceType(Enums.ServiceTypes type);
    }
}
