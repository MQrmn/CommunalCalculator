namespace WebUi
{
    public interface ICalculationService
    {
        public void PutRequest(CalculateRequestData request);
        public void RunCalculation();
        public void FillResultRepository();
        public List<CurrentResult> GetResults();
    }
}
