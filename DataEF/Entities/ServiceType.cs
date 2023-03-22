namespace DataEF
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string ServiceTypeName { get; set; }
        public ICollection<CommunalRate> Rates { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}
