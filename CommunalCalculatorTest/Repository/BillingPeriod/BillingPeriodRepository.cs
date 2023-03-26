using DataEF;
using AutoMapper;

namespace Core
{
    internal class BillingPeriodRepository : Repository, IBillingPeriodRepository
    {
        public BillingPeriodRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public void Put(Core.BillingPeriod billingPeriod)
        {
            var bp = _mapper.Map<DataEF.BillingPeriod>(billingPeriod);
            _dbContext.Add(bp);
            _dbContext.SaveChanges();
        }

        public Core.BillingPeriod GetLast()
        {
            var bp = _dbContext.BillingPeriods.OrderBy(p => p.Id).LastOrDefault();
            var newBp = _mapper.Map<BillingPeriod>(bp);
            return newBp;
        }
    }
}
