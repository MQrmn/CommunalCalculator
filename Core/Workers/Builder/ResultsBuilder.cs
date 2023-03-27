using AutoMapper;

namespace Core
{
    internal class ResultsBuilder
    {
        private RawData _raw;
        private ICalculationResultsRepository _calculationResultsRepository;
        private IMapper _mapper;

        public ResultsBuilder(RawData raw, IMapper mapper, ICalculationResultsRepository calculationResultsRepository)
        {
            _calculationResultsRepository = calculationResultsRepository;
            _raw = raw;
            _mapper = mapper;
        }

        public void GetResults()
        {
            _raw.CalculateAll();
            SetBillingPeriod();
            SetColdWater();
            SetElectroEnergy();
            SetHeatCarrier();
            SetThermalEnergy();
            CalculateCommonCost();
        }

        private void SetColdWater()
        {
            var result = _mapper.Map<ServiceResult>(_raw.ColdWater);
            AddResult(_raw.ColdWater, result);
        }

        private void SetThermalEnergy()
        {
            var result = _mapper.Map<ServiceResult>(_raw.ThermalEnergy);
            AddResult(_raw.ThermalEnergy, result);
        }

        private void SetHeatCarrier()
        {
            var result = _mapper.Map<ServiceResult>(_raw.HeatCarrier);
            AddResult(_raw.HeatCarrier, result);
        }

        private void SetElectroEnergy()
        {
            if(typeof(ElectroEnergyByDayNightMeter).IsInstanceOfType(_raw.ElectroEnergy))
            {
                SetElectroEnergyDay();
                SetElectroEnergyNight();
;            }
            else
            {
                SetElectroEnergyCommon();
            }
        }

        private void SetElectroEnergyCommon()
        {
            var result = _mapper.Map<ServiceResult>(_raw.ElectroEnergy);
            AddResult(_raw.ElectroEnergy, result);
        }

        private void SetElectroEnergyDay()
        {
            var ee = (ElectroEnergyByDayNightMeter)_raw.ElectroEnergy;
            var result = _mapper.Map<ServiceResult>(ee.Day);
            AddResult(ee.Day, result);
        }

        private void SetElectroEnergyNight()
        {
            var ee = (ElectroEnergyByDayNightMeter)_raw.ElectroEnergy;
            var result = _mapper.Map<ServiceResult>(ee.Night);
            AddResult(ee.Night, result);
        }

        private void SetBillingPeriod()
        {
            _calculationResultsRepository.SetBillingPeriod(_raw.BillingPeriod);
        }

        private void AddResult(CommunalService service, ServiceResult result)
        {
            result.BillingPeriod = _raw.BillingPeriod.Id;
            result.Rate = service.Rate.Cost;
            result.Normative = service.Rate.Normative;
            SetMeterValue(service, ref result);
            _calculationResultsRepository.AddResult(result);
        }

        private void SetMeterValue(CommunalService service, ref ServiceResult result)
        {
            if (service.GetType().IsSubclassOf(typeof(CommunalServiceByMeter)))
            {
                var obj = (CommunalServiceByMeter)service;
                result.MeterValue = obj.CurrentValue;
            }
            else
                result.MeterValue = null;
        }

        private void CalculateCommonCost()
        {
            decimal cost = decimal.Zero;
            foreach (var i in _calculationResultsRepository.GetResults())
            {
                cost += i.Cost;
            }
            _calculationResultsRepository.SetCost(cost);
        }
    }
}
