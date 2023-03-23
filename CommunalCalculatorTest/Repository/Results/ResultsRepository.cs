using AutoMapper;
using DataEF;

namespace Core
{
    internal class ResultsRepository : IResultsRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;
        public ResultsRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Addresult(ResultCommon result)
        {
            throw new NotImplementedException();
        }

        public void CheckIsresultsByServiceType(Enums.ServiceTypes type)
        {
            throw new NotImplementedException();
        }

        public void GetResultsByServiceType(Enums.ServiceTypes type)
        {
            throw new NotImplementedException();
        }
    }
}
