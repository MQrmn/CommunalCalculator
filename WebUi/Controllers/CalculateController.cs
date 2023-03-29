using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Diagnostics;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class CalculationController : Controller
    {
        private ICalculationService _calcService;
        public CalculationController(ICalculationService calcService)
        {
            _calcService = calcService;
        }
        public IActionResult PutValues()
        {
            var allServicesEmpty = new RequestData();
            return View(allServicesEmpty);
        }

        [HttpPost]
        public IActionResult CurrentResult(RequestData services)
        {
            if (services is null) return null;

            _calcService.PutRequest(services);
            var res = _calcService.CalculateGetResults();

            ViewBag.CommonCost = _calcService.GetCommonCost();

            return View(res);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            string errMessage;

            if (HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error is CalculatorException)
                errMessage = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error.Message;
            else
                errMessage = "Возникла неизвестная ошибка";

            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ExceptionMessage = errMessage
            });
        }
    }
}
