namespace DataEF.Entities.Rates
{
    internal class ServiceType
    {
        public int Id { get; set; }
        public string ServiceTypeName { get; set; }
        public ICollection<CommunalRates> CommRates { get; set; }
    }
}
