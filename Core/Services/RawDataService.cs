namespace Core
{
    internal class RawDataService
    {
        private IRawDataRepository _rawDataRepository;
        private IRatesRepository _ratesRepository;
        private Core.BillingPeriod _lastBillingPeriod;
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;

        public RawDataService(IRawDataRepository rawDataRepository,
                            IRatesRepository ratesRepository, 
                            IResultsRepository resultsRepository, 
                            IBillingPeriodRepository billingPeriodRepository,
                            IMeterValuesRepository meterValuesRepository)
        {
            _rawDataRepository = rawDataRepository;
            _ratesRepository = ratesRepository;
            _billingPeriodRepository = billingPeriodRepository;
            _meterValuesRepository = meterValuesRepository;
            SetBillingPeriods();
        }

        private void SetBillingPeriods()
        {
            _lastBillingPeriod = _billingPeriodRepository.GetLast();
            var currentBillingPeriod = GetCurrentBillingPeriod();
            _rawDataRepository.SetBillingPeriod(currentBillingPeriod);
            
        }

        private BillingPeriod GetCurrentBillingPeriod()
        {
            if (_lastBillingPeriod is not null)
            {
                return new BillingPeriod(_lastBillingPeriod.Id + 1);
            }
            else
            {
                return new BillingPeriod();
            }
        }

        internal void SetResidentsCount(int residentsCount)
        {
            _rawDataRepository.SetResidentsCount(residentsCount);
        }

        internal void SetColdWaterByNormative() 
        {
            var service = new ColdWaterByNormative(_rawDataRepository.GetResidentsCount());
            SetRateByTypeAddToRepo(service, Enums.ServiceTypes.ColdWater);
        }

        internal void SetColdWaterByMeter(decimal currentValue) 
        {
            var type = Enums.ServiceTypes.ColdWater;
            var previousValue = GetPreviousMeterValueByType(type);
            var service = new ColdWaterByMeter(previousValue, currentValue);
            SetRateByTypeAddToRepo(service, type);
        }

        internal void SetHeatCarrierThermalEnergyByNormative() 
        {
            var residentsCount = _rawDataRepository.GetResidentsCount();
            var hcService = new HeatCarrierByNormative(residentsCount);
            var teService = new ThermalEnergyByNormative(residentsCount);
            teService.HeatCarrierRate = _ratesRepository.GetRateByServiceType(Enums.ServiceTypes.HeatCarrier);
            SetRateByTypeAddToRepo(hcService, Enums.ServiceTypes.HeatCarrier);
            SetRateByTypeAddToRepo(teService, Enums.ServiceTypes.ThermalEnergy);
        }

        internal void SetHeatCarrierThermalEnergyByMeter(decimal heatCarrierCurrentValue) 
        {
            var heatCarrierPreviousValue = GetPreviousMeterValueByType(Enums.ServiceTypes.HeatCarrier);
            var hcService = new HeatCarrierByMeter(heatCarrierPreviousValue, heatCarrierCurrentValue);
            var teService = new ThermalEnergyByMeter(heatCarrierCurrentValue - heatCarrierPreviousValue);
            SetRateByTypeAddToRepo(hcService, Enums.ServiceTypes.HeatCarrier);
            SetRateByTypeAddToRepo(teService, Enums.ServiceTypes.ThermalEnergy);
        }

        internal void SetElectroEnergyByNormative() 
        {
            var residentsCount = _rawDataRepository.GetResidentsCount();
            var service = new ElectroEnergyByNormative(residentsCount);
            SetRateByTypeAddToRepo(service, Enums.ServiceTypes.ElectroEnergyCommon);
        }

        internal void SetElectroEnergyByMeter(decimal currentValue) 
        {
            var previousValue = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyCommon);
            var service = new ElectroEnergyByMeter(previousValue, currentValue);
            SetRateByTypeAddToRepo(service, Enums.ServiceTypes.ElectroEnergyCommon);
        }

        public void SetElectroEnergyByDayMeter(decimal currentValue)
        {
            var prevValue = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyDay);
            var service = new ElectroEnergyByMeter(prevValue, currentValue);
            service.ServiceType = (int)Enums.ServiceTypes.ElectroEnergyDay;
            SetRateByTypeAddToRepo(service, Enums.ServiceTypes.ElectroEnergyDay);
        }

        public void SetElectroEnergyByNightMeter(decimal currentValue)
        {
            var prevValue = GetPreviousMeterValueByType(Enums.ServiceTypes.ElectroEnergyNight);
            var service = new ElectroEnergyByMeter(prevValue, currentValue);
            service.ServiceType = (int)Enums.ServiceTypes.ElectroEnergyNight;
            SetRateByTypeAddToRepo(service, Enums.ServiceTypes.ElectroEnergyNight);
        }

        private void SetRateByTypeAddToRepo(CommunalService s, Enums.ServiceTypes t)
        {
            s.Rate = _ratesRepository.GetRateByServiceType(t);
            _rawDataRepository.AddCommunalService(s);
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
