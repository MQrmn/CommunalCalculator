namespace Core
{
    internal class ColdWaterByNormative : CommunalServiceByNormative
    {
        public ColdWaterByNormative(int residentsCount) : base(residentsCount) 
        {
            ServiceType = (int)Enums.ServiceTypes.ColdWater;
        }
    }
}
