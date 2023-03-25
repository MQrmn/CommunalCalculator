namespace Core
{
    public class BillingPeriod
    {
        public int PeriodId { get; set; }
        public DateOnly Date { get; set; }

        public BillingPeriod( int periodId = 1 ) 
        {
            PeriodId = periodId;
            var now = DateTime.Now;
            Date = new DateOnly(now.Year, now.Month, now.Day);
        }
    }
}
