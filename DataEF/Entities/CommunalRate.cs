namespace DataEF
{
    public class CommunalRate
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public decimal? Normative { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
