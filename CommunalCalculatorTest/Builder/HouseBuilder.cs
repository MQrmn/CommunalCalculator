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

        internal void SetResidentsCount(int reading)
        {
            _house.ResidentsCount = reading;
        }

        internal void SetColdWaterByNormative() 
        {
            var service = new ColdWaterByNormative(_house.ResidentsCount);
            SetColdWaterServices(service);
        }

        internal void SetColdWaterByMeter(int reading) 
        {
            var service = new ColdWaterByMeter(reading);
            SetColdWaterServices(service);
        }

        internal void SetColdWaterByMeter(int readingBefor, int ReadingNow) 
        {
            var service = new ColdWaterByMeter(readingBefor, ReadingNow);
            SetColdWaterServices(service);
        }

        private void SetColdWaterServices(CommunalService s)
        {
            s.Rate = _ratesRepository.GetColdWater();
            _house.ColdWater = s;
        }

        internal void SetHeatCarrierThermalEnergyByNormative() 
        {
            var hcService = new HeatCarrierByNormative(_house.ResidentsCount);
            var teService = new ThermalEnergy();
            SetHeatCarrierThermalEnergyServices(hcService, teService);
        }

        internal void SetHeatCarrierThermalEnergyByByMeter(int reading) 
        {
            var hcService = new HeatCarrierByMeter(reading);
            var teService = new ThermalEnergy();
            SetHeatCarrierThermalEnergyServices(hcService, teService);
        }

        internal void SetHeatCarrierThermalEnergyByMeter(int readingBefor, int ReadingNow) 
        {
            var hcService = new HeatCarrierByMeter(readingBefor, ReadingNow);
            var teService = new ThermalEnergy();
            SetHeatCarrierThermalEnergyServices(hcService, teService);
        }

        private void SetHeatCarrierThermalEnergyServices(CommunalService hcService, CommunalService teService)
        {
            hcService.Rate = _ratesRepository.GetHeatCarrierRate();
            teService.Rate = _ratesRepository.GetThermalEnergy();
            _house.HeatCarrier = hcService;
            _house.ThermalEnergy = teService;
        }
        internal void SetElectroEnergyByNormative() 
        {
            var service = new ElectroEnergyByNormative(_house.ResidentsCount);
            SetElectroEnergyServices(service);
        }

        internal void SetElectroEnergyByMeter(int reading) 
        {
            var service = new ElectroEnergyByMeter(reading);
            SetElectroEnergyServices(service);
        }

        internal void SetElectroEnergyByMeter(int readingBefor, int ReadingNow) 
        {
            var service = new ElectroEnergyByMeter(readingBefor, ReadingNow);
            SetElectroEnergyServices(service);
        }

        private void SetElectroEnergyServices(CommunalService s)
        {
            s.Rate = _ratesRepository.GetElectroEnergyCommon();
            _house.ElectroEnergy = s;
        }

        public void SetElectroEnergyByDayNightMeter(int dayReadingBefore, int dayReadingNow, int nightReadingBefore, int nightReadingNow)
        {
            var eeDay = new ElectroEnergyByMeter(dayReadingBefore, dayReadingNow);
            var eeNight = new ElectroEnergyByMeter(nightReadingBefore, nightReadingNow);

            eeDay.Rate = _ratesRepository.GetElectroEnergyDay();
            eeNight.Rate = _ratesRepository.GetElectroEnergyNight();

            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }


    }
}
