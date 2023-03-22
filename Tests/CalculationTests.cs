using Core;

namespace Tests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void CalculationsByNormative()
        {
            var count = 3;
            var calculator = new Calculator();
            calculator.SetResidentsCount(count);
            calculator.SetElectroEnergy();
            calculator.SetColdWater();
            calculator.SetHotWater();
            var current = calculator.GetResut();

            var expected = new CalculationResult()
            {
                ColdWater = 173.53m * count,
                ElectroEnergy = 701.92m * count,
                HeatCarrier = 143.48m * count,
                ThermalEnergy = 214.21m * count,
                Sum = 1233.14m * count
            };
            Assert.AreEqual(expected.ColdWater, current.ColdWater, 0.01m);
            Assert.AreEqual(expected.ElectroEnergy, current.ElectroEnergy, 0.01m);
            Assert.AreEqual(expected.HeatCarrier, current.HeatCarrier, 0.01m);
            Assert.AreEqual(expected.ThermalEnergy, current.ThermalEnergy, 0.01m);
            Assert.AreEqual(expected.Sum, current.Sum, 0.01m);
        }

        [TestMethod]
        public void CalculationByOneReading()
        {
            var count = 1;
            var calculator = new Calculator();
            calculator.SetResidentsCount(count);
            calculator.SetElectroEnergy();
            calculator.SetColdWater();
            calculator.SetHotWater();
            var current = calculator.GetResut();

            var expected = new CalculationResult()
            {
                ColdWater = 173.53m * count,
                ElectroEnergy = 701.92m * count,
                HeatCarrier = 143.48m * count,
                ThermalEnergy = 214.21m * count,
                Sum = 1233.14m * count
            };
            Assert.AreEqual(expected.ColdWater, current.ColdWater, 0.01m);
            Assert.AreEqual(expected.ElectroEnergy, current.ElectroEnergy, 0.01m);
            Assert.AreEqual(expected.HeatCarrier, current.HeatCarrier, 0.01m);
            Assert.AreEqual(expected.ThermalEnergy, current.ThermalEnergy, 0.01m);
            Assert.AreEqual(expected.Sum, current.Sum, 0.01m);
        }
    }
}