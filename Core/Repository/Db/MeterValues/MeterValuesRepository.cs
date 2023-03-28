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

        public Core.MeterValue GetByTypeAndPeriodId(Enums.ServiceTypes type, int periodId)
        {
            var mv = _dbContext.MeterValues.Where(p => p.ServiceType == (int)type)
                                    .Where(p => p.BillingPeriod == periodId)
                                    .OrderBy(p => p.Id)
                                    .LastOrDefault();

            return _mapper.Map<Core.MeterValue>(mv);
        }

        public void AddRange(List<ServiceResult> values)
        {
            var v = new List<DataEF.MeterValue>();

            foreach (var value in values)
                v.Add(_mapper.Map<DataEF.MeterValue>(value));

            _dbContext.MeterValues.AddRange(v);
            _dbContext.SaveChanges();
        }

        public MeterValue GetLastByType(Enums.ServiceTypes type)
        {
            var mv = _dbContext.MeterValues.Where(p => p.ServiceType == (int)type)
                        .OrderBy(p => p.Id)
                        .LastOrDefault();

            return _mapper.Map<Core.MeterValue>(mv);
        }
    }
}
