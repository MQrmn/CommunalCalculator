namespace Core
{
    internal class HouseBuilder
    {
        private House _house;
        public HouseBuilder()
        {
            _house = new House();
        }
        
        internal void SetResidentsCount(int reading)
        {
            _house.ResidentsCount = reading;
        }

        internal void SetColdWater() 
        {
            _house.ColdWater = new ColdWaterByNormative(_house.ResidentsCount);
        }

        internal void SetColdWater(int reading) 
        {
            _house.ColdWater = new ColdWaterByMeter(reading);
        }

        internal void SetColdWater(int readingBefor, int ReadingNow) 
        {
            _house.ColdWater = new ColdWaterByMeter(readingBefor, ReadingNow);
        }

        internal void SetHotWater() 
        {
            _house.HotWater = new HeatCarrierByNormative(_house.ResidentsCount);
        }

        internal void SetHotWater(int reading) 
        {
            _house.HotWater = new HeatCarrierByMeter(reading);
        }
        internal void SetHotWater(int readingBefor, int ReadingNow) 
        {
            _house.HotWater = new HeatCarrierByMeter(readingBefor, ReadingNow);
        }

        internal void SetElectroEnergy() 
        {
            _house.ElectroEnergy = new ElectroEnergyByNormative(_house.ResidentsCount);
        }

        internal void SetElectroEnergy(int reading) 
        {
            _house.ElectroEnergy = new ElectroEnergyByMeter(reading);
        }

        internal void SetElectroEnergy(int readingBefor, int ReadingNow) 
        {
            _house.ElectroEnergy = new ElectroEnergyByMeter(readingBefor, ReadingNow);
        }

        public void SetElectroEnergy(int dayReadingBefore, int dayReadingNow, int nightReadingBefore, int nightReadingNow)
        {
            var eeDay = new ElectroEnergyByMeter(dayReadingBefore, dayReadingNow);
            var eeNight = new ElectroEnergyByMeter(nightReadingBefore, nightReadingNow);
            _house.ElectroEnergy = new ElectroEnergyByDayNightMeter(eeDay, eeNight);
        }

        internal House GetObject()
        {
            return _house;
        }
    }
}
