using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_andrewPotter.Models;

namespace mission6_andrewPotter.Controllers
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

        public IActionResult getToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult addMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addMovie(Movie response)
        {
            return View("confirmation");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
