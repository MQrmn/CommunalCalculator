namespace DataEF
{
    public class Rate
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public decimal Normative { get; set; }
        public int ServiceType { get; set; }
        public ServiceType ServiceTypeId { get; set; }
    }
}
