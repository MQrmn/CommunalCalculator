using Core;

namespace Tests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void CalculationsByNormative()
        {
            var count = 1;
            var calculator = new Calculator();
            calculator.SetResidentsCount(count);
            calculator.SetElectroEnergy();
            calculator.SetColdWater();
            calculator.SetHotWater();
            var current = calculator.GetResult();

            var expected = new OldResultCommon()
            {
                ColdWater = 173.53m * count,
                ElectroEnergy = 701.92m * count,
                HeatCarrier = 143.48m * count,
                ThermalEnergy = 214.21m * count,
                Sum = 1233.14m * count
            };
            Assert.AreEqual(expected.ColdWater, current.ColdWater.Cost);
            Assert.AreEqual(expected.ElectroEnergy, current.ElectroEnergyCommon.Cost);
            Assert.AreEqual(expected.HeatCarrier, current.HeatCarrier.Cost);
            Assert.AreEqual(expected.ThermalEnergy, current.ThermalEnergy.Cost);
            Assert.AreEqual(expected.Sum, current.CommonCost);
        }

        [TestMethod]
        public void CalculationByValues()
        {
            var count = 1;
            var calculator = new Calculator();
            calculator.SetResidentsCount(count);
            calculator.SetColdWater(4.85m);
            calculator.SetElectroEnergy(164m);
            calculator.SetHotWater(4.01m);
            var current = calculator.GetResult();



            var expected = new OldResultCommon()
            {
                ColdWater = 173.53m * count,
                ElectroEnergy = 701.92m * count,
                HeatCarrier = 143.48m * count,
                ThermalEnergy = 214.21m * count,
                Sum = 1233.14m * count
            };


            Assert.AreEqual(expected.ColdWater, current.ColdWater.Cost);
            Assert.AreEqual(expected.ElectroEnergy, current.ElectroEnergyCommon.Cost);
            Assert.AreEqual(expected.HeatCarrier, current.HeatCarrier.Cost);
            Assert.AreEqual(expected.ThermalEnergy, current.ThermalEnergy.Cost);
            Assert.AreEqual(expected.Sum, current.CommonCost);
        }

        //    [TestMethod]
        //    public void CalculationWithDayNightElectroValues()
        //    {
        //        var count = 1;
        //        var calculator = new Calculator();
        //        calculator.SetResidentsCount(count);
        //        calculator.SetColdWater(4.85m);
        //        calculator.SetElectroEnergy(100m, 100m);
        //        calculator.SetHotWater(4.01m);
        //        var current = calculator.OldGetResut();

        //        var expected = new OldResultCommon()
        //        {
        //            ColdWater = 173.53m * count,
        //            ElectroEnergy = 490m + 231m * count,
        //            HeatCarrier = 143.48m * count,
        //            ThermalEnergy = 214.21m * count,
        //            Sum = 1252.22m * count
        //        };
        //        Assert.AreEqual(expected.ColdWater, current.ColdWater);
        //        Assert.AreEqual(expected.ElectroEnergy, current.ElectroEnergy);
        //        Assert.AreEqual(expected.HeatCarrier, current.HeatCarrier);
        //        Assert.AreEqual(expected.ThermalEnergy, current.ThermalEnergy);
        //        Assert.AreEqual(expected.Sum, current.Sum);
        //    }
    }
}