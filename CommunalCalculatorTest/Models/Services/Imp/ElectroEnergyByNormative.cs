namespace Core
{
    internal class ElectroEnergyByNormative : CommunalServiceByNormative
    {
        public ElectroEnergyByNormative(int residentsCount) : base(residentsCount) 
        {
            ServiceType = (int)Enums.ServiceTypes.ElectroEnergyCommon;
        }

    }
}
