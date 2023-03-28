namespace Core
{
    public interface IBillingPeriodRepository
    {
        public BillingPeriod GetLast();
        public void Put(BillingPeriod billingPeriod);
    }
}
