namespace Core
{
    internal interface IRawDataRepository
    {
        public void SetBillingPeriod(BillingPeriod billingPeriod);
        public BillingPeriod GetBillingPeriod();
        public void SetResidentsCount(int residentsCount);
        public int GetResidentsCount();
        public void AddCommunalService(CommunalService communalService);
        public List<CommunalService> GetAllCommunalServices();
        public void RemoveAllCommunalServices();
    }
}
