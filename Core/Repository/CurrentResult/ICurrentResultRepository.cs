namespace Core
{
    internal interface ICurrentResultRepository
    {
        public void AddResult(ServiceResult result);
        public List<ServiceResult> GetResults();
        public void SetBillingPeriod(BillingPeriod billingPeriod);
        public BillingPeriod GetBillingPeriod();
        public void SetCost(decimal cost);
        public decimal GetCost();
    }
}
