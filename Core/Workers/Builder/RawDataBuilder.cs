namespace Core
{
    internal class RawDataBuilder
    {
        private RawData _raw;
        private IRatesRepository _ratesRepository;
        private Core.BillingPeriod _lastBillingPeriod;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;

        public RawDataBuilder(RawData raw,
                            IRatesRepository ratesRepository, 
                            IResultsRepository resultsRepository, 
                            IBillingPeriodRepository billingPeriodRepository,
                            IMeterValuesRepository meterValuesRepository)
        {
            _raw = raw;
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
                _raw.BillingPeriod = new BillingPeriod(_lastBillingPeriod.Id + 1);
            else
                _raw.BillingPeriod = new BillingPeriod();
        }

        internal void SetResidentsCount(int residentsCount)
        {
            _raw.ResidentsCount = residentsCount;
        }

        internal void SetColdWaterByNormative() 
        {
            var service = new ColdWaterByNormative(_raw.ResidentsCount);
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
            _raw.ColdWater = s;
        }

        internal void SetHeatCarrierThermalEnergyByNormative() 
        {
            var hcService = new HeatCarrierByNormative(_raw.ResidentsCount);
            var teService = new ThermalEnergyByNormative(_raw.ResidentsCount);
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
            _raw.HeatCarrier = hcService;
            _raw.ThermalEnergy = teService;
        }
        internal void SetElectroEnergyByNormative() 
        {
            var service = new ElectroEnergyByNormative(_raw.ResidentsCount);
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
            _raw.ElectroEnergy = s;
        }

        public void SetElectroEnergyByDayNightMeter(decimal currentValueDay, decimal currentValueNight)
        {
            var previousValueDay = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyDay);
            var previousValueNight  = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyNight);
            var eeDay = new ElectroEnergyByMeter(previousValueDay, currentValueDay);
            var eeNight = new ElectroEnergyByMeter(previousValueNight, currentValueNight);
            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();

            _raw.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }

        private decimal GetPreviousMeterValueByType(Enums.ServiceTypes type)
        {
            if (_lastBillingPeriod is not null)
            {
                var lastMeterValue = _meterValuesRepository.GetByTypeAndPeriodId(type, _lastBillingPeriod.Id);
                lastMeterValue = lastMeterValue is null ? _meterValuesRepository.GetLastByType(type) : lastMeterValue;
                if (lastMeterValue is null) return decimal.Zero;

                return lastMeterValue.Value;
            }
            else
            {
                return decimal.Zero;
            }
        }
    }
}
