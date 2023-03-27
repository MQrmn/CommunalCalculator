using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUi;
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
            _calcService.PutRequest(services);
            _calcService.RunCalculation();
            _calcService.FillResultRepository();

            var res = _calcService.GetResults();

            return View(res);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ExceptionMessage = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error.Message
            });
        }
    }
}
