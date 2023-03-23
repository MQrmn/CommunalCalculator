using Core;
using DataEF;
using AutoMapper;
using Core.Mapping;

namespace CommunalCalculator
{
    public class Calculator
    {
        public HouseBuilder _builder;
        public House _house;
        public IRatesRepository _ratesRepositoryStub;
        public IRatesRepository _ratesRepository;
        private IResultsRepository _resultsRepository;
        private ResultBuilder _resultBuilder;
        public AppDbContext _dbContext;
        public static IMapper _mapper;

        public Calculator()
        {
            CreateMapper();
            _dbContext = new AppDbContext();
            _ratesRepository = new RatesRepository(_dbContext, _mapper);
            _resultsRepository = new ResultsRepository(_dbContext, _mapper);
            _builder = new HouseBuilder(_ratesRepository, _resultsRepository);
            _ratesRepositoryStub = new RatesRepositoryStub();
            FillDb();
        }

        private void CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            mapperConfiguration.AssertConfigurationIsValid();
            _mapper = mapperConfiguration.CreateMapper();
        }
        
        // TESTING DB
        private void FillDb()
        {
            var st1 = new ServiceType()
            {
                Id = 1,
                ServiceTypeName = "ХВС"
            };
            var st2 = new ServiceType()
            {
                Id = 2,
                ServiceTypeName = "ЭЭ"
            };
            var st3 = new ServiceType()
            {
                Id = 3,
                ServiceTypeName = "ЭЭ День"
            };
            var st4 = new ServiceType()
            {
                Id = 4,
                ServiceTypeName = "ЭЭ Ночь"
            };
            var st5 = new ServiceType()
            {
                Id = 5,
                ServiceTypeName = "ГВС Теплоноситель"
            };
            var st6 = new ServiceType()
            {
                Id = 6,
                ServiceTypeName = "ГВС Тепловая энергия"
            };

            var cw = _ratesRepositoryStub.GetColdWater();
            var dbCw = new Rate()
            {
                Id = 1,
                Cost = cw.Cost,
                Normative = cw.Normative,
                ServiceType = 1
            };

            var ee = _ratesRepositoryStub.GetElectroEnergyCommon();

            var eeDb = new Rate()
            {
                Id = 2,
                Cost = ee.Cost,
                Normative = ee.Normative,
                ServiceType = 2
            };

            var eeDay = _ratesRepositoryStub.GetElectroEnergyDay();

            var eeDayDb = new Rate()
            {
                Id = 3,
                Cost = eeDay.Cost,
                Normative = eeDay.Normative,
                ServiceType = 3
            };

            var eeNight = _ratesRepositoryStub.GetElectroEnergyNight();

            var eeNightDb = new Rate()
            {
                Id = 4,
                Cost = eeNight.Cost,
                Normative = eeNight.Normative,
                ServiceType = 4
            };

            var hc = _ratesRepositoryStub.GetHeatCarrierRate();

            var hcDb = new Rate()
            {
                Id = 5,
                Cost = hc.Cost,
                Normative = hc.Normative,
                ServiceType = 5
            };

            var te = _ratesRepositoryStub.GetThermalEnergy();

            var teDb = new Rate()
            {
                Id = 6,
                Cost = te.Cost,
                Normative = te.Normative,
                ServiceType = 6
            };

            _dbContext.ServiceTypes.Add(st1);
            _dbContext.ServiceTypes.Add(st2);
            _dbContext.ServiceTypes.Add(st3);
            _dbContext.ServiceTypes.Add(st4);
            _dbContext.ServiceTypes.Add(st5);
            _dbContext.ServiceTypes.Add(st6);

            _dbContext.Rates.Add(dbCw);
            _dbContext.Rates.Add(eeDb);
            _dbContext.Rates.Add(eeDayDb);
            _dbContext.Rates.Add(eeNightDb);
            _dbContext.Rates.Add(hcDb);
            _dbContext.Rates.Add(teDb);
            
            _dbContext.SaveChanges();
        }

        public ResultCommon GetResut()
        {
            _house = _builder.GetObject();
            _resultBuilder = new ResultBuilder(_house);
            ResultCommon resultObj = _resultBuilder.GetResult();
            return resultObj;
        }

        public void SetResidentsCount(int count)
        {
            _builder.SetResidentsCount(count);
        }

        public void SetColdWater() 
        {
            _builder.SetColdWaterByNormative();
        }

        public void SetColdWater(decimal currentMeterValue) 
        {
            _builder.SetColdWaterByMeter(currentMeterValue);
        }

        public void SetHotWater() 
        {
            _builder.SetHeatCarrierThermalEnergyByNormative();
        }

        public void SetHotWater(decimal currentMeterValue) 
        {
            _builder.SetHeatCarrierThermalEnergyByByMeter(currentMeterValue);
        }

        public void SetElectroEnergy() 
        {
            _builder.SetElectroEnergyByNormative();
        }

        public void SetElectroEnergy(decimal currentMeterValue) 
        {
            _builder.SetElectroEnergyByMeter(currentMeterValue);
        }

        public void SetElectroEnergy(decimal currentMeterValueDay, decimal currentMeterValueNight) 
        {
            _builder.SetElectroEnergyByDayNightMeter(currentMeterValueDay, currentMeterValueNight);
        }
    }
}