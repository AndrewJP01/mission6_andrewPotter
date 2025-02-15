using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_andrewPotter.Models;

namespace mission6_andrewPotter.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;
        public HomeController(MoviesContext temp) // Constructor
        { 
            _context = temp;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

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
            _context.Movies.Add(response); // Add record to the database
            _context.SaveChanges(); // commits to the database

            return View("confirmation");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
