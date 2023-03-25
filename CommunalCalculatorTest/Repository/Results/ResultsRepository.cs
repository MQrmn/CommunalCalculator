﻿using AutoMapper;
using DataEF;

namespace Core
{
    internal class ResultsRepository : Repository, IResultsRepository
    {
        public ResultsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public void Addresult(ServiceResult result)
        {
            var r = _mapper.Map<Result>(result);
            _dbContext.Results.Add(r);
        }

        public bool CheckIsresultsByServiceType(Enums.ServiceTypes type)
        {
            var dbResult = _dbContext.Results.Where(p => p.ServiceType == (int)type).Count();
            if (dbResult > 0)
                return true;

            return false;
        }

        public List<ServiceResult> GetResultsByServiceType(Enums.ServiceTypes type)
        {
            var dbResult = _dbContext.Results.Where(p => p.ServiceType == (int)type).ToList();
            var results = new List<ServiceResult>(dbResult.Count);
            
            foreach(var r in dbResult) 
            {
                results.Add(_mapper.Map<ServiceResult>(r));
            }

            return results;
        }
    }
}
