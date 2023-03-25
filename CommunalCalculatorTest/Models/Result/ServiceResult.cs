namespace Core
{
    public class ServiceResult
    {
        public decimal VolumeOfServices { get; set; }
        public decimal Cost { get; set; }
        public int ServiceType { get; set; }
        public decimal? MeterValue { get; set; }
        public int? BillingPeriod { get; set; }
    }  
}
