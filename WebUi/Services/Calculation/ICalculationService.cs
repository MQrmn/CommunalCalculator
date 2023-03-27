namespace WebUi
{
    public interface ICalculationService
    {
        public void PutRequest(RequestData request);
        public void Calculate();
        public List<CurrentResult> CalculateGetResults();
        public decimal GetCommonCost();
    }
}
