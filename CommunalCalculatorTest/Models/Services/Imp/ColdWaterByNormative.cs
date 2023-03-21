namespace Core
{
    internal class ColdWaterByNormative : CommunalServiceByNormative
    {
        public ColdWaterByNormative(int residentsCount) : base(residentsCount) { }

        internal override decimal GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
