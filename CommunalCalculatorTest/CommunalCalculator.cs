using Core;

namespace CommunalCalculator
{
    public class CommunalCalculator
    {
        private HouseBuilder _builder;
        private House _house;
        private AllCommunalRates _rates;

        public CommunalCalculator()
        {
            _builder = new HouseBuilder();
        }

        public void GetResut()
        {
            _house = _builder.GetObject();
        }

        private void SetRates()
        {
            _rates = new AllCommunalRates();
        }

        public void SetResidentsCount(int count)
        {
            _builder.SetResidentsCount(count);
        }

        public void SetColdWater() 
        {
            _builder.SetColdWater();
        }

        public void SetColdWater(int reading) 
        {
            _builder.SetColdWater(reading);
        }

        public void SetColdWater(int readingBefor, int readingNow) 
        {
            _builder.SetColdWater(readingBefor, readingNow);
        }

        public void SetHotWater() 
        {
            _builder.SetHotWater();
        }

        public void SetHotWater(int reading) 
        {
            _builder.SetHotWater(reading);
        }

        public void SetHotWater(int readingBefor, int readingNow) 
        {
            _builder.SetHotWater(readingBefor, readingNow);
        }

        public void SetElectroEnergy() 
        {
            _builder.SetElectroEnergy();
        }

        public void SetElectroEnergy(int reading) 
        {
            _builder.SetElectroEnergy(reading);
        }

        public void SetElectroEnergy(int readingBefore, int readingNow) 
        {
            _builder.SetElectroEnergy(readingBefore, readingNow);
        }

        public void SetElectroEnergy(int dayReadingBefore, int dayReadingNow, int nightReadingBefore, int nightReadingNow)
        {
            _builder.SetElectroEnergy(dayReadingBefore, dayReadingNow, nightReadingBefore, nightReadingNow);
        }

    }
}