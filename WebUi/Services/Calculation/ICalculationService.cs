namespace WebUi
{
    public interface ICalculationService
    {
        public void PutRequest(RequestData request);
        public void RunCalculation();
        public List<CurrentResult> GetResults();
    }
}
