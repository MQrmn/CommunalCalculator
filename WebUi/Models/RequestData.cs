using System.ComponentModel.DataAnnotations;

namespace WebUi
{
    public class RequestData
    {
        private const string messageReq = "Поле обязательно для заполнения";
        private const string messageRegExp = "Введите корректное значение";

        [Required(ErrorMessage = messageReq)]
        [RegularExpression("([.0-9]+)", ErrorMessage = messageRegExp)]
        public decimal ColdWaterMeterValues { get; set; }

        [Required(ErrorMessage = messageReq)]
        [RegularExpression("([.0-9]+)", ErrorMessage = messageRegExp)]
        public decimal HotWaterMeterValue { get; set; }

        [Required(ErrorMessage = messageReq)]
        [RegularExpression("([.0-9]+)", ErrorMessage = messageRegExp)]
        public decimal ElectroEnergyCommonMeterValue { get; set; }

        [Required(ErrorMessage = messageReq)]
        [RegularExpression("([.0-9]+)", ErrorMessage = messageRegExp)]
        public decimal ElectroEnergyDayMeterValue { get; set; }

        [Required(ErrorMessage = messageReq)]
        [RegularExpression("([.0-9]+)", ErrorMessage = messageRegExp)]
        public decimal ElectroEnergyNightMeterValue { get; set; }

        [Required(ErrorMessage = messageReq)]
        [RegularExpression("([.0-9]+)", ErrorMessage = messageRegExp)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public int ResidentsCount { get; set; } = 1;
    }
}
