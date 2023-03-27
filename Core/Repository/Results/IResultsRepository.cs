namespace Core
{
    public interface IResultsRepository
    {
        public void Add(ServiceResult result);
        public void AddRange(List<ServiceResult> results);
    }
}
