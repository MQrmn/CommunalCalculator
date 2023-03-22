namespace Core
{
    public class CalculationResult
    {
        public decimal ColdWater { get; set; }
        public decimal ThermalEnergy { get; set; }
        public decimal HeatCarrier { get; set; }
        public decimal ElectroEnergy { get; set; }
        public decimal Sum { get; set; }

        public override string ToString()
        {
            return $"ColdWater: {ColdWater}, ElectroEnergy: {ElectroEnergy}, HeatCarrier: {HeatCarrier}, ThermalEnergy: {ThermalEnergy}, Sum: {Sum}";
        }
    }

    
}
