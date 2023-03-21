namespace Core
{
    internal class HeatCarrierByNormative : CommunalServiceByNormative
    {
        public HeatCarrierByNormative(int residentsCount) : base(residentsCount) { }

        internal override decimal GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
