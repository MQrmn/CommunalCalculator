using Core;
using DataEF;
using AutoMapper;
using Core.Mapping;

namespace CommunalCalculator
{
    public class Calculator
    {
        private IRawDataRepository _rawDataRepository;
        private RawDataService _rawDataService;
        private IRatesRepository _ratesRepository;
        private IResultsRepository _resultsRepository;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;
        private ICurrentResultRepository _currentResultRepository;
        private CurrentResultsService _currentResultService;
        private AppDbContext _dbContext;
        private static IMapper _mapper;
        private DbWriter _dbWriter;

        public Calculator()
        {
            _dbContext = new AppDbContext();
            InitDb();
            CreateMapper();
               
            _rawDataRepository = new RawDataRepository();
            _currentResultRepository = new CalculationResultsRepository();
            _ratesRepository = new RatesRepository(_dbContext, _mapper);
            _resultsRepository = new ResultsRepository(_dbContext, _mapper);
            _billingPeriodRepository = new BillingPeriodRepository(_dbContext, _mapper);
            _meterValuesRepository = new MeterValuesRepository(_dbContext, _mapper);

            _rawDataService = new RawDataService(_rawDataRepository, _ratesRepository, _resultsRepository, 
                                            _billingPeriodRepository, _meterValuesRepository);

            _currentResultService = new CurrentResultsService(_rawDataRepository, _mapper, _currentResultRepository);

            _dbWriter = new DbWriter(_resultsRepository, _billingPeriodRepository, 
                                        _meterValuesRepository, _currentResultRepository);
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
            _currentResultService.CreateCurrentResult();
            _dbWriter.WriteAll();
            return _currentResultRepository.GetResults();
        }

        public void SetResidentsCount(int count)
        {
            _rawDataService.SetResidentsCount(count);
        }
        
        // Set ColdWater values by stored normatives
        public void SetColdWater() 
        {
            _rawDataService.SetColdWaterByNormative();
        }
        
        //Set ColdWater values by meter values
        public void SetColdWater(decimal currentMeterValue) 
        {
            _rawDataService.SetColdWaterByMeter(currentMeterValue);
        }

        //Set HotWater values by stored normatives
        public void SetHotWater() 
        {
            _rawDataService.SetHeatCarrierThermalEnergyByNormative();
        }

        //Set HotWater values by meter value
        public void SetHotWater(decimal currentMeterValue) 
        {
            _rawDataService.SetHeatCarrierThermalEnergyByMeter(currentMeterValue);
        }

        //Set ElectroEnergy values by stored normative
        public void SetElectroEnergy() 
        {
            _rawDataService.SetElectroEnergyByNormative();
        }

        //Set ElectroEnergy values by meter values
        public void SetElectroEnergy(decimal currentMeterValue) 
        {
            _rawDataService.SetElectroEnergyByMeter(currentMeterValue);
        }

        //Set Day & Night ElectroEnergy values by meter value
        public void SetElectroEnergy(decimal currentMeterValueDay, decimal currentMeterValueNight) 
        {
            _rawDataService.SetElectroEnergyByDayMeter(currentMeterValueDay);
            _rawDataService.SetElectroEnergyByNightMeter(currentMeterValueNight);
        }
    }
}