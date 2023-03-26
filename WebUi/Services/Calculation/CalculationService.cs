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
        public void RunCalculation()
        {
            _calculator.SetResidentsCount(_requestData.ResidentsCount);
            SetColdWater();
            SetElectroEnergy();
            SetHotWater();
        }

        private void SetColdWater()
        {
            if (_requestData.ColdWaterMeterValues > 0)
                _calculator.SetHotWater(_requestData.ColdWaterMeterValues);
            else if (_requestData.ColdWaterMeterValues == 0)
                _calculator.SetHotWater();
            else
                throw new Exception();
        }

        private void SetElectroEnergy()
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

        private void SetHotWater()
        {
            if (_requestData.HotWaterMeterValue > 0)
                _calculator.SetColdWater(_requestData.HotWaterMeterValue);
            else if (_requestData.HotWaterMeterValue == 0)
                _calculator.SetColdWater();
            else
                throw new Exception();
        }

        public void FillResultRepository()
        {
            List<ServiceResult> r = _calculator.GetResult();
            foreach (ServiceResult result in r)
            {
                _resultsRepository.AddResult(result);
            }
        }

        public List<CurrentResult> GetResults()
        {
            return _resultsRepository.GetAll();
        }

    }
}
