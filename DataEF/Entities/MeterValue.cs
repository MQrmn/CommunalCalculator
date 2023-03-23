namespace DataEF
{
    public class MeterValue
    {
        public int Id { get; set; }
        public decimal Volume { get; set; }
        public int ServiceType { get; set; }
        public int BillingPeriod { get; set; }
        public ServiceType ServiceTypeId { get; set; }
        public BillingPeriod BillingPeriodId { get; set; }
    }
}
