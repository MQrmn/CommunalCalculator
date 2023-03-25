namespace DataEF
{
    public class MeterValue
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int ServiceType { get; set; }
        public int BillingPeriod { get; set; }
        public ServiceType ServiceTypeId { get; set; }
        public BillingPeriod BillingPeriodId { get; set; }
    }
}
