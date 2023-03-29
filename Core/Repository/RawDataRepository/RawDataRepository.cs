namespace Core
{
    internal class RawDataRepository : IRawDataRepository
    {
        private List<CommunalService> _communalServices;
        private BillingPeriod _billingPeriod;
        private int _residentsCount;

        public RawDataRepository()
        {
            _communalServices = new();
        }

        public void AddCommunalService(CommunalService communalService)
        {
            _communalServices.Add(communalService);
        }

        public List<CommunalService> GetAllCommunalServices()
        {
            return _communalServices;
        }

        public BillingPeriod GetBillingPeriod()
        {
            return _billingPeriod;
        }

        public int GetResidentsCount()
        {
            return _residentsCount;
        }

        public void RemoveAllCommunalServices()
        {
            _communalServices.Clear();
        }

        public void SetBillingPeriod(BillingPeriod billingPeriod)
        {
            _billingPeriod = billingPeriod;
        }

        public void SetResidentsCount(int residentsCount)
        {
            _residentsCount = residentsCount;
        }
    }
}
