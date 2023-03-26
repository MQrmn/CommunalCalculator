namespace WebUi
{
    public class CurrentResultsRepository : ICurrentResultsRepository
    {
        public List<CurrentResult> Results { get; set; }

        public CurrentResultsRepository()
        {
            Results = new();
        }

        public void AddResult(Core.ServiceResult result)
        {
            Results.Add(new CurrentResult()
            {
                ServiceTypeName = GetServiceTypeNameByType(result.ServiceType),
                VolumeOfServices = result.VolumeOfServices,
                Cost = result.Cost,
                Normative = result.Normative,
                Rate = result.Rate,
                Units = GetUnitsByType(result.ServiceType)
            });
        }

        public List<CurrentResult> GetAll()
        {
            return Results;
        }

        private string GetUnitsByType(int id)
        {
            return id switch
            {
                (int)Core.Enums.ServiceTypes.ColdWater => "М куб.",
                (int)Core.Enums.ServiceTypes.ElectroEnergyCommon => "кВт/ч",
                (int)Core.Enums.ServiceTypes.ElectroEnergyDay => "кВт/ч",
                (int)Core.Enums.ServiceTypes.ElectroEnergyNight => "кВт/ч",
                (int)Core.Enums.ServiceTypes.HeatCarrier => "М куб.",
                (int)Core.Enums.ServiceTypes.ThermalEnergy => "Гкал",
            };
        }

        private string GetServiceTypeNameByType(int id)
        {
            return id switch
            {
                (int)Core.Enums.ServiceTypes.ColdWater => "ХВС",
                (int)Core.Enums.ServiceTypes.ElectroEnergyCommon => "ЭЭ",
                (int)Core.Enums.ServiceTypes.ElectroEnergyDay => "ЭЭ День",
                (int)Core.Enums.ServiceTypes.ElectroEnergyNight => "ЭЭ Ночь",
                (int)Core.Enums.ServiceTypes.HeatCarrier => "ГВС Теплоноситель ",
                (int)Core.Enums.ServiceTypes.ThermalEnergy => "ГВС Тепловая Энергия",
            };
        }

        private void SetCommonCost()
        {

        }
    }
}
