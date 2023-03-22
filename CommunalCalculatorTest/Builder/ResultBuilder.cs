namespace Core
{
    internal class ResultBuilder
    {
        private CalculationResult _result;
        private House _house;
        internal ResultBuilder(House house) 
        {
            _house = house;
            _result = new CalculationResult();
        }

        public CalculationResult GetResult()
        {
            var cw = _house.ColdWater.GetSalary();
            var hc = _house.HeatCarrier.GetSalary();
            var te = _house.ThermalEnergy.GetSalary();
            var ee = _house.ElectroEnergy.GetSalary();

            _result.ColdWater = Math.Round(cw, 2);
            _result.HeatCarrier = Math.Round(hc, 2);
            _result.ThermalEnergy = Math.Round(te, 2);
            _result.ElectroEnergy = Math.Round(ee, 2);
            _result.Sum = Math.Round(cw + hc + te + ee, 2);

            return _result;
        }
    }
}
