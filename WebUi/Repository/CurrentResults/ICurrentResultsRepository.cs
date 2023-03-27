namespace WebUi
{
    public interface ICurrentResultsRepository
    {
        public void AddResult(CurrentResult result);
        public List<CurrentResult> GetAll();
        public void SetCommonCost(decimal cost);
        public decimal GetCommonCost();
    }
}
