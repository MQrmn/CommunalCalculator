using AutoMapper;
using DataEF;
using SQLitePCL;

namespace Core
{
    internal class ResultsBuilder
    {
        private House _house;
        private AllResults _result;
        private IMapper _mapper;

        public ResultsBuilder(House house, IMapper mapper)
        {
            _result = new AllResults();
            _house = house;
            _mapper = mapper;
        }

        public AllResults GetResults()
        {
            _house.CalculateAll();
            SetColdWater();
            SetThermalEnergy();
            SetHeatCarrier();
            SetElectroEnergy();
            CalculateCommonCost();
            return _result;
        }

        private void CalculateCommonCost()
        {
            _result.CommonCost = _result.ColdWater.Cost + _result.HeatCarrier.Cost + _result.ThermalEnergy.Cost;
            if (_result.ElectroEnergyCommon is not null)
            {
                _result.CommonCost += _result.ElectroEnergyCommon.Cost;
            }
            else
            {
                _result.CommonCost += _result.ElectroEnergyDay.Cost + _result.ElectroEnergyNight.Cost;
            }
        }

        private void SetColdWater()
        {
            _result.ColdWater = _mapper.Map<ServiceResult>(_house.ColdWater);
            _result.ColdWater.BillingPeriod = _house.BillingPeriod.PeriodId;
            SetMeterValue(_house.ColdWater, _result.ColdWater);
        }

        private void SetMeterValue(CommunalService service, ServiceResult result)
        {
            if (service.GetType().IsSubclassOf(typeof(CommunalServiceByMeter)))
            {
                var obj = (CommunalServiceByMeter)service;
                result.MeterValue = obj.CurrentValue;
            }
            else
                result.MeterValue = null;
        }

        private void SetThermalEnergy()
        {
            _result.ThermalEnergy = _mapper.Map<ServiceResult>(_house.ThermalEnergy);
            _result.ThermalEnergy.BillingPeriod = _house.BillingPeriod.PeriodId;
            SetMeterValue(_house.ThermalEnergy, _result.ThermalEnergy);
        }

        private void SetHeatCarrier()
        {
            _result.HeatCarrier = _mapper.Map<ServiceResult>(_house.HeatCarrier);
            _result.HeatCarrier.BillingPeriod = _house.BillingPeriod.PeriodId;
            SetMeterValue(_house.HeatCarrier, _result.HeatCarrier);
        }

        private void SetElectroEnergy()
        {
            if(_house.ElectroEnergy.GetType().IsSubclassOf(typeof(ElectroEnergyByDayNightMeter))) 
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
            _result.ElectroEnergyCommon = _mapper.Map<ServiceResult>(_house.ElectroEnergy);
            _result.ElectroEnergyCommon.BillingPeriod = _house.BillingPeriod.PeriodId;
            SetMeterValue(_house.ElectroEnergy, _result.ElectroEnergyCommon);
        }

        private void SetElectroEnergyDay()
        {
            var ee = (ElectroEnergyByDayNightMeter)_house.ElectroEnergy;
            _result.ElectroEnergyDay = _mapper.Map<ServiceResult>(ee.Day);
            _result.ElectroEnergyDay.BillingPeriod = _house.BillingPeriod.PeriodId;
            SetMeterValue(ee.Day, _result.ElectroEnergyDay);
        }

        private void SetElectroEnergyNight()
        {
            var ee = (ElectroEnergyByDayNightMeter)_house.ElectroEnergy;
            _result.ElectroEnergyNight = _mapper.Map<ServiceResult>(ee.Night);
            _result.ElectroEnergyNight.BillingPeriod = _house.BillingPeriod.PeriodId;
            SetMeterValue(ee.Night, _result.ElectroEnergyDay);
        }
    }
}
