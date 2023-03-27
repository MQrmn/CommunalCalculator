using Core;
using DataEF;
using AutoMapper;
using Core.Mapping;

namespace CommunalCalculator
{
    public class Calculator
    {
        private RawData _raw;
        private RawDataBuilder _houseBuilder;
        private IRatesRepository _ratesRepository;
        private IResultsRepository _resultsRepository;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;
        private ICalculationResultsRepository _calculationResultsRepository;
        private ResultsBuilder _resultBuilder;
        private AppDbContext _dbContext;
        private static IMapper _mapper;
        DbWriter _dbWriter;

        public Calculator()
        {
            _dbContext = new AppDbContext();
            InitDb();
            CreateMapper();
               
            _raw = new RawData();
            _calculationResultsRepository = new CalculationResultsRepository();
            _ratesRepository = new RatesRepository(_dbContext, _mapper);
            _resultsRepository = new ResultsRepository(_dbContext, _mapper);
            _billingPeriodRepository = new BillingPeriodRepository(_dbContext, _mapper);
            _meterValuesRepository = new MeterValuesRepository(_dbContext, _mapper);

            _houseBuilder = new RawDataBuilder(_raw, _ratesRepository, _resultsRepository, 
                                            _billingPeriodRepository, _meterValuesRepository);

            _resultBuilder = new ResultsBuilder(_raw, _mapper, _calculationResultsRepository);

            _dbWriter = new DbWriter(_resultsRepository, _billingPeriodRepository, 
                                        _meterValuesRepository, _calculationResultsRepository);
        }

        private void InitDb()
        {
            var dbInit = new DbInitialiser(_dbContext);
            dbInit.InitDb();
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
            _dbWriter.WriteAll();
            return _calculationResultsRepository.GetResults();
        }

        public void SetResidentsCount(int count)
        {
            _houseBuilder.SetResidentsCount(count);
        }
        
        // Set ColdWater values by stored normatives
        public void SetColdWater() 
        {
            _houseBuilder.SetColdWaterByNormative();
        }
        
        //Set ColdWater values by meter values
        public void SetColdWater(decimal currentMeterValue) 
        {
            _houseBuilder.SetColdWaterByMeter(currentMeterValue);
        }

        //Set HotWater values by stored normatives
        public void SetHotWater() 
        {
            _houseBuilder.SetHeatCarrierThermalEnergyByNormative();
        }

        //Set HotWater values by meter value
        public void SetHotWater(decimal currentMeterValue) 
        {
            _houseBuilder.SetHeatCarrierThermalEnergyByByMeter(currentMeterValue);
        }

        //Set ElectroEnergy values by stored normative
        public void SetElectroEnergy() 
        {
            _houseBuilder.SetElectroEnergyByNormative();
        }

        //Set ElectroEnergy values by meter values
        public void SetElectroEnergy(decimal currentMeterValue) 
        {
            _houseBuilder.SetElectroEnergyByMeter(currentMeterValue);
        }

        //Set Day & Night ElectroEnergy values by meter value
        public void SetElectroEnergy(decimal currentMeterValueDay, decimal currentMeterValueNight) 
        {
            _houseBuilder.SetElectroEnergyByDayNightMeter(currentMeterValueDay, currentMeterValueNight);
        }
    }
}