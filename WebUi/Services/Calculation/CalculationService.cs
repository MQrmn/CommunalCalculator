using CommunalCalculator;
using Core;

namespace WebUi
{
    public class CalculationService : ICalculationService
    {
        private RequestData _requestData;
        private Calculator _calculator;
        private ICurrentResultsRepository _resultsRepository;

        public CalculationService(Calculator calculator,
                                    ICurrentResultsRepository resultsRepository)
        {
            _calculator = calculator;
            _resultsRepository = resultsRepository;
        }

        public void PutRequest(RequestData requestData)
        {
            _requestData = requestData;
        }

        public List<CurrentResult> CalculateGetResults()
        {
            Calculate();
            return _resultsRepository.GetAll();
        }

        public void Calculate()
        {
            _calculator.SetResidentsCount(_requestData.ResidentsCount);
            PutColdWater();
            PutElectroEnergy();
            PutHotWater();
            FillResultRepository();
        }

        private void PutColdWater()
        {
            if (_requestData.ColdWaterMeterValues > 0)
                _calculator.SetHotWater(_requestData.ColdWaterMeterValues);
            else if (_requestData.ColdWaterMeterValues == 0)
                _calculator.SetHotWater();
            else
                throw new Exception();
        }

        private void PutElectroEnergy()
        {
            if (_requestData.ElectroEnergyDayMeterValue > 0 && _requestData.ElectroEnergyNightMeterValue > 0)
                _calculator.SetElectroEnergy(_requestData.ElectroEnergyDayMeterValue, _requestData.ElectroEnergyNightMeterValue);
            else if (_requestData.ElectroEnergyCommonMeterValue > 0)
                _calculator.SetElectroEnergy(_requestData.ElectroEnergyCommonMeterValue);
            else if (_requestData.ElectroEnergyCommonMeterValue == 0)
                _calculator.SetElectroEnergy();
            else
                throw new Exception();
        }

        private void PutHotWater()
        {
            if (_requestData.HotWaterMeterValue > 0)
                _calculator.SetColdWater(_requestData.HotWaterMeterValue);
            else if (_requestData.HotWaterMeterValue == 0)
                _calculator.SetColdWater();
            else
                throw new Exception();
        }

        private void FillResultRepository()
        {
            List<ServiceResult> results = _calculator.GetResult();
            foreach (ServiceResult r in results)
            {
                _resultsRepository.AddResult(MapResultToCurrentResult(r));
            }
        }

        public CurrentResult MapResultToCurrentResult(Core.ServiceResult result)
        {
            return new CurrentResult()
            {
                ServiceTypeName = GetServiceTypeNameByType(result.ServiceType),
                VolumeOfServices = result.VolumeOfServices,
                Cost = result.Cost,
                Normative = result.Normative,
                Rate = result.Rate,
                Units = GetUnitsByType(result.ServiceType)
            };
        }

        private string GetUnitsByType(int id)
        {
            return id switch
            {
                (int)Core.Enums.ServiceTypes.ColdWater => "М³",
                (int)Core.Enums.ServiceTypes.ElectroEnergyCommon => "кВт/ч",
                (int)Core.Enums.ServiceTypes.ElectroEnergyDay => "кВт/ч",
                (int)Core.Enums.ServiceTypes.ElectroEnergyNight => "кВт/ч",
                (int)Core.Enums.ServiceTypes.HeatCarrier => "М³",
                (int)Core.Enums.ServiceTypes.ThermalEnergy => "Гкал",
            };
        }

        private string GetServiceTypeNameByType(int id)
        {
            return id switch
            {
                (int)Core.Enums.ServiceTypes.ColdWater => "ХВС",
                (int)Core.Enums.ServiceTypes.ElectroEnergyCommon => "ЭЭ",
                (int)Core.Enums.ServiceTypes.ElectroEnergyDay => "ЭЭ День",
                (int)Core.Enums.ServiceTypes.ElectroEnergyNight => "ЭЭ Ночь",
                (int)Core.Enums.ServiceTypes.HeatCarrier => "ГВС Теплоноситель ",
                (int)Core.Enums.ServiceTypes.ThermalEnergy => "ГВС Тепловая Энергия",
            };
        }
        public decimal GetCommonCost()
        {
            var results = _resultsRepository.GetAll();

            decimal cost = decimal.Zero;
            foreach(var r in results)
            {
                cost += r.Cost;
            }
            return cost;
        }
    }
}
