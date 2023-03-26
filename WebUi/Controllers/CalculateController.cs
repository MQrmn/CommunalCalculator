using Microsoft.AspNetCore.Mvc;
using WebUi;

namespace WebUi.Controllers
{
    public class CalculateController : Controller
    {
        private ICalculationService _calcService;
        public CalculateController(ICalculationService calcService)
        {
            _calcService = calcService;
        }
        public IActionResult GetValues()
        {
            var allServicesEmpty = new CalculateRequestData();
            return View(allServicesEmpty);
        }

        [HttpPost]
        public IActionResult CurrentResult(CalculateRequestData services)
        {
            _calcService.PutRequest(services);
            _calcService.RunCalculation();
            _calcService.FillResultRepository();

            var res = _calcService.GetResults();

            foreach(var r in res)
            {
                Console.WriteLine(r.Cost);
            }

            return View(res);
        }
    }
}
