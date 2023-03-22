using Core;
namespace Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void GetRateInstance()
        {
            var calc = new Calculator();
            var rate = calc._ratesRepository.GetColdWater();
            Assert.IsNotNull(rate);
            Assert.AreEqual(rate.Cost, 35.78m);
        }
    }
}
