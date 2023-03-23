namespace DataEF
{
    public class ServiceVolume
    {
        public int Id { get; set; }
        public decimal Volume { get; set; }
        public int ServiceType { get; set; }
        public ServiceType ServiceTypeId { get; set; }
    }
}
