namespace Core
{
    internal interface IBillingPeriodRepository
    {
        public BillingPeriod GetLast();
        public void Put(BillingPeriod billingPeriod);
    }
}
