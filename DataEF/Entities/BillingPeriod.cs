namespace DataEF
{
    public class BillingPeriod
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<MeterValue> MeterValues { get; set; }
    }
}
