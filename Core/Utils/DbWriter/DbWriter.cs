namespace Core
{
    internal class DbWriter
    {
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;
        private IResultsRepository _resultRepository;
        private ICurrentResultRepository _calculationResultsRepository;

        public DbWriter(    IResultsRepository resultRepository,
                            IBillingPeriodRepository billingPeriodRepository,
                            IMeterValuesRepository meterValuesRepository,
                            ICurrentResultRepository calculationResultsRepository)
        {
            _billingPeriodRepository = billingPeriodRepository;
            _meterValuesRepository = meterValuesRepository;
            _resultRepository = resultRepository;
            _calculationResultsRepository = calculationResultsRepository;
        }

        public void WriteAll()
        {
            WriteBillingPeriod();
            WriteMeterValues();
            WriteServiceResults();
        }

        private void WriteBillingPeriod()
        {
            _billingPeriodRepository.Put(_calculationResultsRepository.GetBillingPeriod());
        }

        private void WriteMeterValues()
        {
            var all = _calculationResultsRepository.GetResults();
            var onlyWithMeterValues = all.Where(p => p.MeterValue != null).ToList();
            _meterValuesRepository.AddRange(onlyWithMeterValues);
        }

        private void WriteServiceResults()
        {
            _resultRepository.AddRange(_calculationResultsRepository.GetResults());
        }

    }
}
