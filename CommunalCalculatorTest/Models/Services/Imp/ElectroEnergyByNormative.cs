﻿namespace Core
{
    internal class ElectroEnergyByNormative : CommunalServiceByNormative
    {
        public ElectroEnergyByNormative(int residentsCount) : base(residentsCount) 
        {
            Type = Enums.ServiceTypes.ElectroEnergyCommon;
        }

    }
}
