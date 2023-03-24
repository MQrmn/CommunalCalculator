using DataEF;
using AutoMapper;

namespace Core.Repository
{
    internal class BillingPeriodRepository : IBillingPeriodRepository
    {
        AppDbContext _dbContext;
        private IMapper _mapper;

        public BillingPeriodRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Put(Core.BillingPeriod billingPeriod)
        {
            var bp = _mapper.Map<DataEF.BillingPeriod>(billingPeriod);
            _dbContext.Add(bp);
            _dbContext.SaveChanges();
        }

        public Core.BillingPeriod GetLast()
        {
            var bp = _dbContext.BillingPeriods.OrderBy(p => p.Id).Last();
            return _mapper.Map<Core.BillingPeriod>(bp);
        }
    }
}
