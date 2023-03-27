using System.ComponentModel.DataAnnotations;

namespace WebUi
{
    public class RequestData
    {
        [Required(ErrorMessage = "Поле обязательно для заполнени")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ColdWaterMeterValues { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнени")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal HotWaterMeterValue { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнени")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ElectroEnergyCommonMeterValue { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнени")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ElectroEnergyDayMeterValue { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнени")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        public decimal ElectroEnergyNightMeterValue { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнени")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Значение должно быть положительным числом")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public int ResidentsCount { get; set; } = 1;
    }
}
