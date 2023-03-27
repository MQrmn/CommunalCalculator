namespace Core
{
    internal class HouseBuilder
    {
        private House _house;
        private IRatesRepository _ratesRepository;
        private Core.BillingPeriod _lastBillingPeriod;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;

        public HouseBuilder(House house,
                            IRatesRepository ratesRepository, 
                            IResultsRepository resultsRepository, 
                            IBillingPeriodRepository billingPeriodRepository,
                            IMeterValuesRepository meterValuesRepository)
        {
            _house = house;
            _ratesRepository = ratesRepository;
            _billingPeriodRepository = billingPeriodRepository;
            _meterValuesRepository = meterValuesRepository;
            SetBillingPeriods();
        }

        private void SetBillingPeriods()
        {
            _lastBillingPeriod = _billingPeriodRepository.GetLast();
            SetCurrentBillingPeriod();
        }

        private void SetCurrentBillingPeriod()
        {
            if (_lastBillingPeriod is not null)
                _house.BillingPeriod = new BillingPeriod(_lastBillingPeriod.Id + 1);
            else
                _house.BillingPeriod = new BillingPeriod();
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
            var previousValue = GetPreviousMeterValueByType(Enums.ServiceTypes.ColdWater);
            var service = new ColdWaterByMeter(previousValue, currentValue);
            SetColdWaterServiceRate(service);
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

        internal void SetHeatCarrierThermalEnergyByByMeter(decimal heatCarrierCurrentValue) 
        {
            var heatCarrierpreviousValue = GetPreviousMeterValueByType(Enums.ServiceTypes.HeatCarrier);
            var hcService = new HeatCarrierByMeter(heatCarrierpreviousValue, heatCarrierCurrentValue);
            var teService = new ThermalEnergyByMeter(heatCarrierCurrentValue - heatCarrierpreviousValue);
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
            var previousValue = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyCommon);
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
            var previousValueDay = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyDay);
            var previousValueNight  = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyNight);
            var eeDay = new ElectroEnergyByMeter(previousValueDay, currentValueDay);
            var eeNight = new ElectroEnergyByMeter(previousValueNight, currentValueNight);
            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();

            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }

        private decimal GetPreviousMeterValueByType(Enums.ServiceTypes type)
        {
            if (_lastBillingPeriod is not null)
            {
                var lastMeterValue = _meterValuesRepository.GetByTypeAndPeriodId(type, _lastBillingPeriod.Id);
                lastMeterValue = lastMeterValue is null ? _meterValuesRepository.GetLastByType(type) : lastMeterValue;
                return lastMeterValue.Value;
            }
            else
            {
                return decimal.Zero;
            }
        }
    }
}
