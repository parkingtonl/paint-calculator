using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaintCalculator.Models;

namespace PaintCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate([FromBody]PaintModel paintViewModel)
        {
            var length = 0M;
            var width = 0M;
            var height = 0M;
            var factor = 3.321M; // represents the coverage of paint

            if (!ModelState.IsValid ) // Standard test for modek data
            {
                return Json(new { Success = false, Message = "Error in calculator." });
            }

            try
            {
                decimal.TryParse(paintViewModel.Length, out length);
                decimal.TryParse(paintViewModel.Width, out width);
                decimal.TryParse(paintViewModel.Height, out height);
                paintViewModel.Area = String.Format("{0:0.#####}", length * width);
                paintViewModel.Paint = String.Format("{0:0.#####}", 2 * height * ( length + width) * factor); // factor represents the coverage of paint
                paintViewModel.Volume = String.Format("{0:0.#####}", length * width * height);
            }

            catch (Exception e)
            {
                return Json(new { Success = false, Length = paintViewModel.Length, Message = $"Error calculating length. {e.Message}" });
            }

            return Json(new { Success = true, Area = paintViewModel.Area, Paint = paintViewModel.Paint, Volume = paintViewModel.Volume });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
