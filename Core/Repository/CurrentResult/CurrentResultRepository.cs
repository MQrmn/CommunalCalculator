namespace Core
{
    internal class CalculationResultsRepository : ICurrentResultRepository
    {
        public List<ServiceResult> Results { get; set; } 
        public decimal CommonCost { get; set; }
        public BillingPeriod BillingPeriod { get; set; }

        public CalculationResultsRepository()
        {
            Results = new List<ServiceResult>();
        }

        public void AddResult(ServiceResult result)
        {
            Results.Add(result);
        }

        public List<ServiceResult> GetResults() 
        { 
            return Results;
        }

        public void SetBillingPeriod(BillingPeriod billingPeriod)
        {
            BillingPeriod = billingPeriod;
        }

        public BillingPeriod GetBillingPeriod()
        {
            return BillingPeriod;
        }

        public void SetCost(decimal cost)
        {
            CommonCost = cost;
        }

        public decimal GetCost()
        {
            return CommonCost;
        }
    }
}
