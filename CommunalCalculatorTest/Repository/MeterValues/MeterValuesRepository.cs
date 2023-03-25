using AutoMapper;
using DataEF;

namespace Core
{
    internal class MeterValuesRepository : Repository, IMeterValuesRepository
    {
        public MeterValuesRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public void Put(MeterValue value)
        {
            throw new NotImplementedException();
        }

        public Core.MeterValue GetLastByTypeAndPeriodId(Enums.ServiceTypes type, int periodId)
        {
            var mv = _dbContext.MeterValues.Where(p => p.ServiceType == (int)type)
                                    .Where(p => p.BillingPeriod == periodId)
                                    .OrderBy(p => p.Id)
                                    .LastOrDefault();

            return _mapper.Map<Core.MeterValue>(mv);
        }
    }
}
