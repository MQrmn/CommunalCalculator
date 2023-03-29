using AutoMapper;

namespace Core
{
    internal class CurrentResultsService
    {
        private IRawDataRepository _rawDataRepository;
        private ICurrentResultRepository _currentResultsRepository;
        private IMapper _mapper;

        public CurrentResultsService(IRawDataRepository rawDataRepository, 
                                    IMapper mapper, 
                                    ICurrentResultRepository currentResultsRepository)
        {
            _currentResultsRepository = currentResultsRepository;
            _rawDataRepository = rawDataRepository;
            _mapper = mapper;
        }

        public void CreateCurrentResult()
        {
            SetBillingPeriod();
            RunAllCalculating();
            FillCurrentResultsRepository();
        }

        public void RunAllCalculating()
        {
            _currentResultsRepository.SetBillingPeriod(_rawDataRepository.GetBillingPeriod());
            var rawData = _rawDataRepository.GetAllCommunalServices();
            rawData.ForEach(o => o.Calculate());
        }

        private void FillCurrentResultsRepository()
        {
            var calculatedRawData = _rawDataRepository.GetAllCommunalServices();

            foreach (var service in calculatedRawData )
            {
                var result = _mapper.Map<ServiceResult>(service);
                AddResult(service, result);
            }
        }

        private void SetBillingPeriod()
        {
            _currentResultsRepository.SetBillingPeriod(_rawDataRepository.GetBillingPeriod());
        }

        private void AddResult(CommunalService service, ServiceResult result)
        {
            result.BillingPeriod = _rawDataRepository.GetBillingPeriod().Id;
            result.Rate = service.Rate.Cost;
            result.Normative = service.Rate.Normative;
            SetMeterValue(service, ref result);
            _currentResultsRepository.AddResult(result);
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
    }
}
