namespace WebUi
{
    public interface ICalculationService
    {
        public void PutRequest(RequestData request);
        public void RunCalculation();
        public void FillResultRepository();
        public List<CurrentResult> GetResults();
    }
}
