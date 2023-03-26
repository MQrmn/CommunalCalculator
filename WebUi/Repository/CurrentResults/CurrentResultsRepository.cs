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
                ServiceTypeName = GetServiceTypeName(result.ServiceType),
                VolumeOfServices = result.VolumeOfServices,
                Cost = result.Cost
            });
        }

        public List<CurrentResult> GetAll()
        {
            return Results;
        }

        private string GetServiceTypeName(int id)
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
    }
}
