namespace DataEF
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string ServiceTypeName { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
