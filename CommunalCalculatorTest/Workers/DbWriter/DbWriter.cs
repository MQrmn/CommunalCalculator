namespace Core
{
    internal class DbWriter
    {
        private IBillingPeriodRepository _billingPeriodRepository;
        private IMeterValuesRepository _meterValuesRepository;
        private IResultsRepository _resultRepository;
        private ICalculationResultsRepository _calculationResultsRepository;

        public DbWriter(    IResultsRepository resultRepository,
                            IBillingPeriodRepository billingPeriodRepository,
                            IMeterValuesRepository meterValuesRepository,
                            ICalculationResultsRepository calculationResultsRepository)
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
            _meterValuesRepository.AddRange(_calculationResultsRepository.GetResults());
        }

        private void WriteServiceResults()
        {
            _resultRepository.AddRange(_calculationResultsRepository.GetResults());
        }

    }
}
