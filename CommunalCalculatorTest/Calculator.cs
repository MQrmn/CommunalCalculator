using Core;

namespace CommunalCalculator
{
    public class Calculator
    {
        private HouseBuilder _builder;
        private House _house;
        private IRatesRepository _ratesRepository;
        private ResultBuilder _resultBuilder;

        public Calculator()
        {
            _ratesRepository = new RatesRepository();
            _builder = new HouseBuilder(_ratesRepository);
        }

        public CalculationResult GetResut()
        {
            _house = _builder.GetObject();
            _resultBuilder = new ResultBuilder(_house);
            CalculationResult resultObj = _resultBuilder.GetResult();
            return resultObj;
        }

        public void SetResidentsCount(int count)
        {
            _builder.SetResidentsCount(count);
        }

        public void SetColdWater() 
        {
            _builder.SetColdWaterByNormative();
        }

        public void SetColdWater(decimal reading) 
        {
            _builder.SetColdWaterByMeter(reading);
        }

        public void SetColdWater(decimal readingBefor, decimal readingNow) 
        {
            _builder.SetColdWaterByMeter(readingBefor, readingNow);
        }

        public void SetHotWater() 
        {
            _builder.SetHeatCarrierThermalEnergyByNormative();
        }

        public void SetHotWater(decimal reading) 
        {
            _builder.SetHeatCarrierThermalEnergyByByMeter(reading);
        }

        public void SetHotWater(decimal readingBefor, decimal readingNow) 
        {
            _builder.SetHeatCarrierThermalEnergyByMeter(readingBefor, readingNow);
        }

        public void SetElectroEnergy() 
        {
            _builder.SetElectroEnergyByNormative();
        }

        public void SetElectroEnergy(decimal reading) 
        {
            _builder.SetElectroEnergyByMeter(reading);
        }

        public void SetElectroEnergy(decimal readingBefore, decimal readingNow) 
        {
            _builder.SetElectroEnergyByMeter(readingBefore, readingNow);
        }

        public void SetElectroEnergy(decimal dayReadingBefore, decimal dayReadingNow, decimal nightReadingBefore, decimal nightReadingNow)
        {
            _builder.SetElectroEnergyByDayNightMeter(dayReadingBefore, dayReadingNow, nightReadingBefore, nightReadingNow);
        }

    }
}