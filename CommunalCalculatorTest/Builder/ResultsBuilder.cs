using AutoMapper;
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
        }

        private void SetThermalEnergy()
        {
            _result.ThermalEnergy= _mapper.Map<ServiceResult>(_house.ThermalEnergy);
        }

        private void SetHeatCarrier()
        {
            _result.HeatCarrier = _mapper.Map<ServiceResult>(_house.HeatCarrier);
        }

        private void SetElectroEnergy()
        {
            if(_house.ElectroEnergy.GetType() == typeof(ElectroEnergyByDayNightMeter)) 
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
        }

        private void SetElectroEnergyDay()
        {
            var ee = (ElectroEnergyByDayNightMeter)_house.ElectroEnergy;
            _result.ElectroEnergyDay = _mapper.Map<ServiceResult>(ee.Day);
        }

        private void SetElectroEnergyNight()
        {
            var ee = (ElectroEnergyByDayNightMeter)_house.ElectroEnergy;
            _result.ElectroEnergyDay = _mapper.Map<ServiceResult>(ee.Night);
        }
    }
}
