using AutoMapper;
using DataEF;

namespace Core
{
    internal abstract class Repository
    {
        private protected AppDbContext _dbContext;
        private protected IMapper _mapper;

        public Repository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
