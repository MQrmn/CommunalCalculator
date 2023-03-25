using Core;
using DataEF;
using AutoMapper;
using Core.Mapping;

namespace CommunalCalculator
{
    public class Calculator
    {
        private HouseBuilder _houseBuilder;
        public House _house;
        public IRatesRepository _ratesRepositoryStub;
        public IRatesRepository _ratesRepository;
        private IResultsRepository _resultsRepository;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;
        private ICalculationResultsRepository _calculationResultsRepository;
        private ResultsBuilder _resultBuilder;
        public AppDbContext _dbContext;
        public static IMapper _mapper;
        DbWriter _dbWriter;

        public Calculator()
        {
            CreateMapper();
            _house = new House();
            _dbContext = new AppDbContext();
            _calculationResultsRepository = new CalculationResultsRepository();

            _ratesRepository = new RatesRepository(_dbContext, _mapper);
            _resultsRepository = new ResultsRepository(_dbContext, _mapper);
            _billingPeriodRepository = new BillingPeriodRepository(_dbContext, _mapper);
            _meterValuesRepository = new MeterValuesRepository(_dbContext, _mapper);
            _houseBuilder = new HouseBuilder(_house, _ratesRepository, _resultsRepository, _billingPeriodRepository, _meterValuesRepository);
            _resultBuilder = new ResultsBuilder(_house, _mapper, _calculationResultsRepository);
            _dbWriter = new DbWriter(_resultsRepository, _billingPeriodRepository, _meterValuesRepository, _calculationResultsRepository);
            
            var dbFiller = new OnInitDbFiller(_dbContext);
            dbFiller.FillDb();
        }

        private void CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            mapperConfiguration.AssertConfigurationIsValid();
            _mapper = mapperConfiguration.CreateMapper();
        }
        
        public List<ServiceResult> GetResult()
        {
            _resultBuilder.GetResults();
            return _calculationResultsRepository.GetResults();
        }

        public void SetResidentsCount(int count)
        {
            _houseBuilder.SetResidentsCount(count);
        }

        public void SetColdWater() 
        {
            _houseBuilder.SetColdWaterByNormative();
        }

        public void SetColdWater(decimal currentMeterValue) 
        {
            _houseBuilder.SetColdWaterByMeter(currentMeterValue);
        }

        public void SetHotWater() 
        {
            _houseBuilder.SetHeatCarrierThermalEnergyByNormative();
        }

        public void SetHotWater(decimal currentMeterValue) 
        {
            _houseBuilder.SetHeatCarrierThermalEnergyByByMeter(currentMeterValue);
        }

        public void SetElectroEnergy() 
        {
            _houseBuilder.SetElectroEnergyByNormative();
        }

        public void SetElectroEnergy(decimal currentMeterValue) 
        {
            _houseBuilder.SetElectroEnergyByMeter(currentMeterValue);
        }

        public void SetElectroEnergy(decimal currentMeterValueDay, decimal currentMeterValueNight) 
        {
            _houseBuilder.SetElectroEnergyByDayNightMeter(currentMeterValueDay, currentMeterValueNight);
        }
    }
}