namespace Core
{
    public class BillingPeriod
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        //public BillingPeriod()
        //{

        //}
        public BillingPeriod(int id = 1)
        {
            Id = id;
            var now = DateTime.Now;
            Date = new DateOnly(now.Year, now.Month, now.Day);
        }
    }
}
