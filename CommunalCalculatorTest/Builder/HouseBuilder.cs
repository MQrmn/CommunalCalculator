namespace Core
{
    public class HouseBuilder
    {
        private House _house;
        private IRatesRepository _ratesRepository;

        public HouseBuilder(IRatesRepository ratesRepository, IResultsRepository resultsRepository)
        {
            _house = new House();
            _ratesRepository = ratesRepository;
        }

        internal House GetObject()
        {
            return _house;
        }

        internal void SetResidentsCount(int residentsCount)
        {
            _house.ResidentsCount = residentsCount;
        }

        internal void SetColdWaterByNormative() 
        {
            var service = new ColdWaterByNormative(_house.ResidentsCount);
            SetColdWaterServiceRate(service);
        }

        internal void SetColdWaterByMeter(decimal currentValue) 
        {
            // Get previous values from db
            var previousValue = 0m;
            var service = new ColdWaterByMeter(previousValue, currentValue);
            SetColdWaterServiceRate(service);
        }

        private void SetColdWaterServiceRate(CommunalService s)
        {
            s.Rate = _ratesRepository.GetColdWater();
            _house.ColdWater = s;
        }

        internal void SetHeatCarrierThermalEnergyByNormative() 
        {
            var hcService = new HeatCarrierByNormative(_house.ResidentsCount);
            var teService = new ThermalEnergyByNormative(_house.ResidentsCount);
            teService.HeatCarrierRate = _ratesRepository.GetHeatCarrierRate();
            SetHeatCarrierThermalEnergyServiceRate(hcService, teService);
        }

        internal void SetHeatCarrierThermalEnergyByByMeter(decimal currentValue) 
        {
            // Get previous values from db
            var previousValue = 0m;
            var hcService = new HeatCarrierByMeter(previousValue, currentValue);
            var teService = new ThermalEnergyByMeter(currentValue - previousValue);
            SetHeatCarrierThermalEnergyServiceRate(hcService, teService);
        }

        private void SetHeatCarrierThermalEnergyServiceRate(CommunalService hcService, CommunalService teService)
        {
            hcService.Rate = _ratesRepository.GetHeatCarrierRate();
            teService.Rate = _ratesRepository.GetThermalEnergy();
            _house.HeatCarrier = hcService;
            _house.ThermalEnergy = teService;
        }
        internal void SetElectroEnergyByNormative() 
        {
            var service = new ElectroEnergyByNormative(_house.ResidentsCount);
            SetElectroEnergyServiceRate(service);
        }

        internal void SetElectroEnergyByMeter(decimal currentValue) 
        {
            // Get previous values from db
            var previousValue = 0m;
            var service = new ElectroEnergyByMeter(previousValue, currentValue);
            SetElectroEnergyServiceRate(service);
        }

        private void SetElectroEnergyServiceRate(CommunalService s)
        {
            s.Rate = _ratesRepository.GetElectroEnergyCommon();
            _house.ElectroEnergy = s;
        }

        public void SetElectroEnergyByDayNightMeter(decimal currentValueDay, decimal currentValueNight)
        {
            // Get previous values from db
            var previousValueDay = 0m;
            var previousValueNight = 0m;
            var eeDay = new ElectroEnergyByMeter(previousValueDay, currentValueDay);
            var eeNight = new ElectroEnergyByMeter(previousValueNight, currentValueNight);
            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();
            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }
    }
}
