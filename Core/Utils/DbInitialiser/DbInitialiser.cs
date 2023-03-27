using DataEF;

namespace Core
{
    internal class DbInitialiser
    {
        private AppDbContext _dbContext;
        public DbInitialiser(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitDb()
        {
            if (!CheckIsDbCreatedAndFilled())
                FillDb();
        }

        private bool CheckIsDbCreatedAndFilled()
        {
            _dbContext.Database.EnsureCreated();
            var rates = _dbContext.ServiceTypes.Join(
                                            _dbContext.Rates, s => s.Id, r => r.ServiceType, 
                                            (r, s) => new { }).Count();
            if (rates < 6)
                return false;

            return true;
        }

        public void FillDb()
        {
            var st = new List<ServiceType>()
            {
                new ServiceType() { Id = (int)Enums.ServiceTypes.ColdWater, ServiceTypeName = "ХВС" },
                new ServiceType() { Id = (int)Enums.ServiceTypes.ElectroEnergyCommon, ServiceTypeName = "ЭЭ" },
                new ServiceType() { Id = (int)Enums.ServiceTypes.ElectroEnergyDay, ServiceTypeName = "ЭЭ День" },
                new ServiceType() { Id = (int)Enums.ServiceTypes.ElectroEnergyNight, ServiceTypeName = "ЭЭ Ночь" },
                new ServiceType() { Id = (int)Enums.ServiceTypes.HeatCarrier, ServiceTypeName = "ГВС Теплоноситель" },
                new ServiceType() { Id = (int)Enums.ServiceTypes.ThermalEnergy, ServiceTypeName = "ГВС Тепловая энергия" }
            };

            var r = new List<Rate>
            {
                new Rate() { Id = (int)Enums.ServiceTypes.ColdWater, Cost = 35.78m, Normative = 4.85m, 
                                                            ServiceType = (int)Enums.ServiceTypes.ColdWater },
                new Rate() { Id = (int)Enums.ServiceTypes.ElectroEnergyCommon, Cost = 4.28m, Normative = 164m, 
                                                            ServiceType = (int)Enums.ServiceTypes.ElectroEnergyCommon },
                new Rate() { Id = (int)Enums.ServiceTypes.ElectroEnergyDay, Cost = 4.9m, Normative = 0, 
                                                            ServiceType = (int)Enums.ServiceTypes.ElectroEnergyDay },
                new Rate() { Id = (int)Enums.ServiceTypes.ElectroEnergyNight, Cost = 2.31m, Normative = 0, 
                                                            ServiceType = (int)Enums.ServiceTypes.ElectroEnergyNight},
                new Rate() { Id = (int)Enums.ServiceTypes.HeatCarrier, Cost = 35.78m, Normative = 4.01m, 
                                                            ServiceType = (int)Enums.ServiceTypes.HeatCarrier },
                new Rate() { Id = (int)Enums.ServiceTypes.ThermalEnergy, Cost = 998.69m, Normative = 0.05349m, 
                                                            ServiceType = (int)Enums.ServiceTypes.ThermalEnergy }
            };

            _dbContext.ServiceTypes.AddRange(st);
            _dbContext.Rates.AddRange(r);
            _dbContext.SaveChanges();
        }
    }
}
