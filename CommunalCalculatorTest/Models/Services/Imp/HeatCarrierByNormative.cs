namespace Core
{
    internal class HeatCarrierByNormative : CommunalServiceByNormative
    {
        public HeatCarrierByNormative(int residentsCount) : base(residentsCount) { }

        internal override double GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
