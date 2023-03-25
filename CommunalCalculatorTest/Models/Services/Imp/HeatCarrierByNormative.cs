namespace Core
{
    internal class HeatCarrierByNormative : CommunalServiceByNormative
    {
        public HeatCarrierByNormative(int residentsCount) : base(residentsCount) 
        {
            ServiceType = (int)Enums.ServiceTypes.HeatCarrier;
        }

    }
}
