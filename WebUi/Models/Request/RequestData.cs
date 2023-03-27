using System.ComponentModel.DataAnnotations;

namespace WebUi
{
    public class RequestData
    {
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ColdWaterMeterValues { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal HotWaterMeterValue { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ElectroEnergyCommonMeterValue { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ElectroEnergyDayMeterValue { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ElectroEnergyNightMeterValue { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public int ResidentsCount { get; set; } = 1;
    }
}
