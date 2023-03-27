namespace WebUi
{
    public class CurrentResultsRepository : ICurrentResultsRepository
    {
        public List<CurrentResult> Results { get; set; }

        public decimal CommonCost { get; set; }

        public CurrentResultsRepository()
        {
            Results = new();
        }

        public void AddResult(CurrentResult result)
        {
            Results.Add(result);
        }

        public List<CurrentResult> GetAll()
        {
            return Results;
        }

        public void SetCommonCost(decimal cost)
        {
            CommonCost = cost;
        }

        public decimal GetCommonCost(decimal cost)
        {
            return CommonCost;
        }
    }
}
