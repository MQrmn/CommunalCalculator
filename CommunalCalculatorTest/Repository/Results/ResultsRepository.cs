using AutoMapper;
using DataEF;

namespace Core
{
    internal class ResultsRepository : Repository, IResultsRepository
    {
        public ResultsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public void Add(ServiceResult result)
        {
            var r = _mapper.Map<Result>(result);
            _dbContext.Results.Add(r);
            _dbContext.SaveChanges();
        }
        public void AddRange(List<ServiceResult> results)
        {
           var r = new List<Result>();
            foreach (var result in results)
                r.Add(_mapper.Map<Result>(result));

            _dbContext.AddRange(r);
            _dbContext.SaveChanges();
        }
    }
}
