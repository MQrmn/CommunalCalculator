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
            var dbFiller = new OnInitDbFiller(_dbContext);
            dbFiller.FillDb();
        }

        private void CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            mapperConfiguration.AssertConfigurationIsValid();
            _mapper = mapperConfiguration.CreateMapper();
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