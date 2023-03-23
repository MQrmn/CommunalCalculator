namespace DataEF
{
    public class Result
    {
        public int Id { get; set; } 
        public decimal VolumeOfServices { get; set; }
        public decimal Cost { get; set; }
        public int ServiceType { get; set; }
        public int BillingPeriod { get; set; }
        public ServiceType ServiceTypeId { get; set; }
        public BillingPeriod BillingPeriodId { get; set; }

    }
}
