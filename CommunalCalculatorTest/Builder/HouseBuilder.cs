namespace Core
{
    internal class HouseBuilder
    {
        private House _house;
        private IRatesRepository _ratesRepository;

        public HouseBuilder(IRatesRepository ratesRepository)
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

        internal void SetColdWaterByMeter(decimal reading) 
        {
            var service = new ColdWaterByMeter(reading);
            SetColdWaterServiceRate(service);
        }

        internal void SetColdWaterByMeter(decimal readingBefor, decimal ReadingNow) 
        {
            var service = new ColdWaterByMeter(readingBefor, ReadingNow);
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

        internal void SetHeatCarrierThermalEnergyByByMeter(decimal reading) 
        {
            var hcService = new HeatCarrierByMeter(reading);
            var teService = new ThermalEnergyByMeter(reading);
            SetHeatCarrierThermalEnergyServiceRate(hcService, teService);
        }

        internal void SetHeatCarrierThermalEnergyByMeter(decimal readingBefor, decimal ReadingNow) 
        {
            var hcService = new HeatCarrierByMeter(readingBefor, ReadingNow);
            var teService = new ThermalEnergyByMeter(readingBefor, ReadingNow);
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

        internal void SetElectroEnergyByMeter(decimal reading) 
        {
            var service = new ElectroEnergyByMeter(reading);
            SetElectroEnergyServiceRate(service);
        }

        internal void SetElectroEnergyByMeter(decimal readingBefor, decimal ReadingNow) 
        {
            var service = new ElectroEnergyByMeter(readingBefor, ReadingNow);
            SetElectroEnergyServiceRate(service);
        }

        private void SetElectroEnergyServiceRate(CommunalService s)
        {
            s.Rate = _ratesRepository.GetElectroEnergyCommon();
            _house.ElectroEnergy = s;
        }

        public void SetElectroEnergyByDayNightMeter(decimal dayReading, decimal nightReading)
        {
            var eeDay = new ElectroEnergyByMeter(dayReading);
            var eeNight = new ElectroEnergyByMeter(nightReading);
            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();
            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }

        public void SetElectroEnergyByDayNightMeter(decimal dayReadingBefore, decimal dayReadingNow, decimal nightReadingBefore, decimal nightReadingNow)
        {
            var eeDay = new ElectroEnergyByMeter(dayReadingBefore, dayReadingNow);
            var eeNight = new ElectroEnergyByMeter(nightReadingBefore, nightReadingNow);
            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();
            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }
    }
}
