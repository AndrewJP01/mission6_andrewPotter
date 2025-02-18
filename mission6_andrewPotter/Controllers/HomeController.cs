using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index() //just the index
        {
            return View();
        }

        public IActionResult getToKnowJoel() //something to get to know homie Joel
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            // Fetch categories from the database
            var categories = _context.Categories.ToList();

            // Ensure that categories are not null and are assigned to ViewData
            ViewData["Categories"] = categories;

            // Return the view
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (!ModelState.IsValid) { // Add the movie to the database
                _context.Movies.Add(movie);
                _context.SaveChanges();

                // Redirect to the movie list page and pass the updated list of movies
                return View("confirmation"); }

            else {
                return View(movie);
                }
        }


        [HttpGet]

        public IActionResult MovieList()
        {
            // Eagerly load the related Category data with each Movie
            var movies = _context.Movies.Include(m => m.Category).ToList();
            // Return the view
            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            // Fetch the movie from the database
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            // Fetch categories from the database
            var categories = _context.Categories.ToList();
            // Ensure that categories are not null and are assigned to ViewData
            ViewData["Categories"] = categories;
            // Return the view
            return View("EditMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie response)
        {
            if (!ModelState.IsValid)
            {
                // Update the record in the database
                _context.Movies.Update(response);
                // Commit the changes to the database
                _context.SaveChanges();
                // Redirect to the test page
                return RedirectToAction("MovieList");
            }

            else
            {
                return View(response);
            }
           
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            // Fetch the movie from the database
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            // Return the view
            return View("DeleteMovie", recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie response)
        {
            // Remove the record from the database
            _context.Movies.Remove(response);
            // Commit the changes to the database
            _context.SaveChanges();
            // Redirect to the test page
            return RedirectToAction("MovieList");
        }   
    }
}
