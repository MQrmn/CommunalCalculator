namespace WebUi
{
    public interface ICurrentResultsRepository
    {
        public void AddResult(Core.ServiceResult result);
        public List<CurrentResult> GetAll();
    }
}
