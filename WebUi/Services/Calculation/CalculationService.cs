using CommunalCalculator;
using Core;

namespace WebUi
{
    public class CalculationService : ICalculationService
    {
        private CalculateRequestData _requestData;
        private Calculator _calculator;
        private ICurrentResultsRepository _resultsRepository;

        public CalculationService(Calculator calculator,
                                    ICurrentResultsRepository resultsRepository)
        {
            _calculator = calculator;
            _resultsRepository = resultsRepository;
        }

        public void PutRequest(CalculateRequestData requestData)
        {
            _requestData = requestData;
        }
        public void RunCalculation()
        {
            _calculator.SetResidentsCount(_requestData.ResidentsCount);
            _calculator.SetColdWater();
            _calculator.SetElectroEnergy();
            _calculator.SetHotWater();
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
