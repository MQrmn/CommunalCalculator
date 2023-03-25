namespace Core
{
    internal class HouseBuilder
    {
        private House _house;
        private IRatesRepository _ratesRepository;
        private Core.BillingPeriod _lastBillingPeriod;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;

        public HouseBuilder(IRatesRepository ratesRepository, 
                            IResultsRepository resultsRepository, 
                            IBillingPeriodRepository billingPeriodRepository,
                            IMeterValuesRepository meterValuesRepository)
        {
            _house = new House();
            _ratesRepository = ratesRepository;
            _billingPeriodRepository = billingPeriodRepository;
            _meterValuesRepository = meterValuesRepository;
            SetLastBillingPeriod();
        }

        internal House GetObject()
        {
            return _house;
        }

        private void SetLastBillingPeriod()
        {
            _lastBillingPeriod = _billingPeriodRepository.GetLast();
        }

        internal void SetResidentsCount(int residentsCount)
        {
            _house.ResidentsCount = residentsCount;
        }

        internal void SetColdWaterByNormative() 
        {
            var service = new ColdWaterByNormative(_house.ResidentsCount);
            SetColdWaterServiceRate(service);
        }

        internal void SetColdWaterByMeter(decimal currentValue) 
        {
            var lastMeterValue = GetLastMeterValue(Enums.ServiceTypes.ColdWater);
            var previousValue = lastMeterValue is not null ? lastMeterValue.Volume : decimal.Zero;
            var service = new ColdWaterByMeter(previousValue, currentValue);
            SetColdWaterServiceRate(service);
        }

        private MeterValue GetLastMeterValue(Enums.ServiceTypes type)
        {
            if (_lastBillingPeriod is not null)
                return _meterValuesRepository.GetLastByTypeAndPeriodId(type, _lastBillingPeriod.PeriodId);
            else
                return null;
        }

        private void SetColdWaterServiceRate(CommunalService s)
        {
            s.Rate = _ratesRepository.GetColdWater();
            _house.ColdWater = s;
        }

        internal void SetHeatCarrierThermalEnergyByNormative() 
        {
            var hcService = new HeatCarrierByNormative(_house.ResidentsCount);
            var teService = new ThermalEnergyByNormative(_house.ResidentsCount);
            teService.HeatCarrierRate = _ratesRepository.GetHeatCarrierRate();
            SetHeatCarrierThermalEnergyServiceRate(hcService, teService);
        }

        internal void SetHeatCarrierThermalEnergyByByMeter(decimal currentValue) 
        {
            // Get previous values from db
            var previousValue = 0m;
            var hcService = new HeatCarrierByMeter(previousValue, currentValue);
            var teService = new ThermalEnergyByMeter(currentValue - previousValue);
            SetHeatCarrierThermalEnergyServiceRate(hcService, teService);
        }

        private void SetHeatCarrierThermalEnergyServiceRate(CommunalService hcService, CommunalService teService)
        {
            hcService.Rate = _ratesRepository.GetHeatCarrierRate();
            teService.Rate = _ratesRepository.GetThermalEnergy();
            _house.HeatCarrier = hcService;
            _house.ThermalEnergy = teService;
        }
        internal void SetElectroEnergyByNormative() 
        {
            var service = new ElectroEnergyByNormative(_house.ResidentsCount);
            SetElectroEnergyServiceRate(service);
        }

        internal void SetElectroEnergyByMeter(decimal currentValue) 
        {
            // Get previous values from db
            var previousValue = 0m;
            var service = new ElectroEnergyByMeter(previousValue, currentValue);
            SetElectroEnergyServiceRate(service);
        }

        private void SetElectroEnergyServiceRate(CommunalService s)
        {
            s.Rate = _ratesRepository.GetElectroEnergyCommon();
            _house.ElectroEnergy = s;
        }

        public void SetElectroEnergyByDayNightMeter(decimal currentValueDay, decimal currentValueNight)
        {
            // Get previous values from db
            var previousValueDay = 0m;
            var previousValueNight = 0m;
            var eeDay = new ElectroEnergyByMeter(previousValueDay, currentValueDay);
            var eeNight = new ElectroEnergyByMeter(previousValueNight, currentValueNight);
            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();
            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }
    }
}
