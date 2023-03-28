using Microsoft.EntityFrameworkCore;
using DataEF;
using AutoMapper;

namespace Core
{
    internal class RatesRepository : Repository, IRatesRepository
    {
        public RatesRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public CommunalRate GetColdWater()
        {
            return GetRateByServiceType(Enums.ServiceTypes.ColdWater);
        }

        public CommunalRate GetElectroEnergyCommon()
        {
            return GetRateByServiceType(Enums.ServiceTypes.ElectroEnergyCommon);
        }

        public CommunalRate GetElectroEnergyDay()
        {
            return GetRateByServiceType(Enums.ServiceTypes.ElectroEnergyDay);
        }

        public CommunalRate GetElectroEnergyNight()
        {
            return GetRateByServiceType(Enums.ServiceTypes.ElectroEnergyNight);
        }

        public CommunalRate GetHeatCarrierRate()
        {
            return GetRateByServiceType(Enums.ServiceTypes.HeatCarrier);
        }

        public CommunalRate GetThermalEnergy()
        {
            return GetRateByServiceType(Enums.ServiceTypes.ThermalEnergy);
        }

        private CommunalRate GetRateByServiceType(Enums.ServiceTypes type)
        {
            var r = _dbContext.Rates.Where(p => p.ServiceType == (int)type).OrderBy(p => p.Id).Last();
            return _mapper.Map<CommunalRate>(r);
        }
    }
}
