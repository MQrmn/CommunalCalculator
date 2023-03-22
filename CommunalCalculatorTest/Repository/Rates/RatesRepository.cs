using Microsoft.EntityFrameworkCore;
using DataEF;
using AutoMapper;

namespace Core
{
    public class RatesRepository : IRatesRepository
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
            return GetRateByServiceType((int)Enums.ServiceTypes.ColdWater);
        }

        public CommunalRate GetElectroEnergyCommon()
        {
            return GetRateByServiceType((int)Enums.ServiceTypes.ElectroEnergyCommon);
        }

        public CommunalRate GetElectroEnergyDay()
        {
            return GetRateByServiceType((int)Enums.ServiceTypes.ElectroEnergyDay);
        }

        public CommunalRate GetElectroEnergyNight()
        {
            return GetRateByServiceType((int)Enums.ServiceTypes.ElectroEnergyNight);
        }

        public CommunalRate GetHeatCarrierRate()
        {
            return GetRateByServiceType((int)Enums.ServiceTypes.HeatCarrier);
        }

        public CommunalRate GetThermalEnergy()
        {
            return GetRateByServiceType((int)Enums.ServiceTypes.ThermalEnergy);
        }

        private CommunalRate GetRateByServiceType(int type)
        {
            var r = _dbContext.Rates.Where(p => p.ServiceTypeId == type).OrderBy(p => p.Id).Last();
            return _mapper.Map<CommunalRate>(r);
        }
    }
}
