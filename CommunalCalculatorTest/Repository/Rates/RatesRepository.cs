using Microsoft.EntityFrameworkCore;
using DataEF;
using AutoMapper;

namespace Core
{
    internal class RatesRepository : IRatesRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public RatesRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public CommunalRate GetColdWater()
        {
            var r = _dbContext.Rates.Where(p => p.ServiceTypeId == 1).ToList<Rate>();


            throw new NotImplementedException();
        }

        public CommunalRate GetElectroEnergyCommon()
        {
            throw new NotImplementedException();
        }

        public CommunalRate GetElectroEnergyDay()
        {
            throw new NotImplementedException();
        }

        public CommunalRate GetElectroEnergyNight()
        {
            throw new NotImplementedException();
        }

        public CommunalRate GetHeatCarrierRate()
        {
            throw new NotImplementedException();
        }

        public CommunalRate GetThermalEnergy()
        {
            throw new NotImplementedException();
        }
    }
}
