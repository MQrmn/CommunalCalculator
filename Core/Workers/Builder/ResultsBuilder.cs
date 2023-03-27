using AutoMapper;

namespace Core
{
    internal class ResultsBuilder
    {
        private House _house;
        private ICalculationResultsRepository _calculationResultsRepository;
        private IMapper _mapper;

        public ResultsBuilder(House house, IMapper mapper, ICalculationResultsRepository calculationResultsRepository)
        {
            _calculationResultsRepository = calculationResultsRepository;
            _house = house;
            _mapper = mapper;
        }

        public void GetResults()
        {
            _house.CalculateAll();
            SetBillingPeriod();
            SetColdWater();
            SetElectroEnergy();
            SetHeatCarrier();
            SetThermalEnergy();
            CalculateCommonCost();
        }

        private void SetColdWater()
        {
            var result = _mapper.Map<ServiceResult>(_house.ColdWater);
            AddResult(_house.ColdWater, result);
        }

        private void SetThermalEnergy()
        {
            var result = _mapper.Map<ServiceResult>(_house.ThermalEnergy);
            AddResult(_house.ThermalEnergy, result);
        }

        private void SetHeatCarrier()
        {
            var result = _mapper.Map<ServiceResult>(_house.HeatCarrier);
            AddResult(_house.HeatCarrier, result);
        }

        private void SetElectroEnergy()
        {
            if(typeof(ElectroEnergyByDayNightMeter).IsInstanceOfType(_house.ElectroEnergy))
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
            var result = _mapper.Map<ServiceResult>(_house.ElectroEnergy);
            AddResult(_house.ElectroEnergy, result);
        }

        private void SetElectroEnergyDay()
        {
            var ee = (ElectroEnergyByDayNightMeter)_house.ElectroEnergy;
            var result = _mapper.Map<ServiceResult>(ee.Day);
            AddResult(ee.Day, result);
        }

        private void SetElectroEnergyNight()
        {
            var ee = (ElectroEnergyByDayNightMeter)_house.ElectroEnergy;
            var result = _mapper.Map<ServiceResult>(ee.Night);
            AddResult(ee.Night, result);
        }

        private void SetBillingPeriod()
        {
            _calculationResultsRepository.SetBillingPeriod(_house.BillingPeriod);
        }

        private void AddResult(CommunalService service, ServiceResult result)
        {
            result.BillingPeriod = _house.BillingPeriod.Id;
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
