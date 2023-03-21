using Core;

namespace CommunalCalculator
{
    public class CommunalCalculator
    {
        private HouseBuilder _builder;
        private House _house;
        private IRatesRepository _ratesRepository;

        public CommunalCalculator()
        {
            _ratesRepository = new RatesRepository();
            _builder = new HouseBuilder(_ratesRepository);
        }

        public void GetResut()
        {
            _house = _builder.GetObject();
        }

        public void SetResidentsCount(int count)
        {
            _builder.SetResidentsCount(count);
        }

        public void SetColdWater() 
        {
            _builder.SetColdWaterByNormative();
        }

        public void SetColdWater(int reading) 
        {
            _builder.SetColdWaterByMeter(reading);
        }

        public void SetColdWater(int readingBefor, int readingNow) 
        {
            _builder.SetColdWaterByMeter(readingBefor, readingNow);
        }

        public void SetHotWater() 
        {
            _builder.SetHeatCarrierThermalEnergyByNormative();
        }

        public void SetHotWater(int reading) 
        {
            _builder.SetHeatCarrierThermalEnergyByByMeter(reading);
        }

        public void SetHotWater(int readingBefor, int readingNow) 
        {
            _builder.SetHeatCarrierThermalEnergyByMeter(readingBefor, readingNow);
        }

        public void SetElectroEnergy() 
        {
            _builder.SetElectroEnergyByNormative();
        }

        public void SetElectroEnergy(int reading) 
        {
            _builder.SetElectroEnergyByMeter(reading);
        }

        public void SetElectroEnergy(int readingBefore, int readingNow) 
        {
            _builder.SetElectroEnergyByMeter(readingBefore, readingNow);
        }

        public void SetElectroEnergy(int dayReadingBefore, int dayReadingNow, int nightReadingBefore, int nightReadingNow)
        {
            _builder.SetElectroEnergyByDayNightMeter(dayReadingBefore, dayReadingNow, nightReadingBefore, nightReadingNow);
        }

    }
}