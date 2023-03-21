namespace Core
{
    internal class ElectroEnergyByNormative : CommunalServiceByNormative
    {
        public ElectroEnergyByNormative(int residentsCount) : base(residentsCount) { }
        internal override double GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
