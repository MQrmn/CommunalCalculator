namespace Core
{
    internal interface IResultsRepository
    {
        public void Add(ServiceResult result);
        public void AddRange(List<ServiceResult> results);
    }
}
