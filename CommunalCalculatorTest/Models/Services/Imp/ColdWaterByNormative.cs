namespace Core
{
    internal class ColdWaterByNormative : CommunalServiceByNormative
    {
        public ColdWaterByNormative(int residentsCount) : base(residentsCount) { }

        internal override double GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
