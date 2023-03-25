namespace Core
{
    internal class OldResultBuilder
    {
        private OldResultCommon _result;
        private House _house;
        internal OldResultBuilder(House house) 
        {
            _house = house;
            _result = new OldResultCommon();
        }
        public OldResultCommon GetResult()
        {
            var cw = _house.ColdWater.Calculate();
            var hc = _house.HeatCarrier.Calculate();
            var te = _house.ThermalEnergy.Calculate();
            var ee = _house.ElectroEnergy.Calculate();

            _result.ColdWater = Math.Round(cw, 2);
            _result.HeatCarrier = Math.Round(hc, 2);
            _result.ThermalEnergy = Math.Round(te, 2);
            _result.ElectroEnergy = Math.Round(ee, 2);
            _result.Sum = Math.Round(cw + hc + te + ee, 2);

            return _result;
        }
    }
}
