namespace Core
{
    internal class ColdWaterByNormative : CommunalServiceByNormative
    {
        public ColdWaterByNormative(int residentsCount) : base(residentsCount) 
        {
            Type = Enums.ServiceTypes.ColdWater;
        }
    }
}
