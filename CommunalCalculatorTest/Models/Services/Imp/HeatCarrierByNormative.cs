namespace Core
{
    internal class HeatCarrierByNormative : CommunalServiceByNormative
    {
        public HeatCarrierByNormative(int residentsCount) : base(residentsCount) 
        {
            Type = Enums.ServiceTypes.HeatCarrier;
        }

    }
}
