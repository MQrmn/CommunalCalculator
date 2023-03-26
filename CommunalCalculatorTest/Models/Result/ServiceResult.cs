namespace Core
{
    public class ServiceResult
    {
        public decimal? MeterValue { get; set; }
        public decimal VolumeOfServices { get; set; }
        public decimal Normative { get; set; }
        public decimal Rate { get; set; }
        public decimal Cost { get; set; }
        public int ServiceType { get; set; }
        public int? BillingPeriod { get; set; }
        
    }  
}
