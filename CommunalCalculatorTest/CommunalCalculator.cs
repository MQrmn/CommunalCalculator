using Core;

namespace CommunalCalculator
{
    public class CommunalCalculator
    {
        private House _house;
        public CommunalCalculator()
        {
            _house = new House();
        }
        public void SetResidentsCount(int count)
        {

        }

        public void SetColdWater(int number) { }
        public void SetColdWater(int numberFrom, int numberTo) { }

        public void SetHotWater(int number) { }
        public void SetHotWater(int numberFrom, int numberTo) { }

        public void SetElectroEnergy(int number) { }
        public void SetElectroEnergy(int numberFrom, int numberTo) { }

        public void GetResut() { }
    }
}