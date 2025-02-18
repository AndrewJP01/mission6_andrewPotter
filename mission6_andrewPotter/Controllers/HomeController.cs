using System.Diagnostics;
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

        // this get shows the add movie view
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

        // posts the added movie into the database
        [HttpPost]
        public IActionResult addMovie(Movie response)
        {
            _context.Movies.Add(response); // Add record to the database
            _context.SaveChanges(); // commits to the database

            return View("confirmation");
        }

        //gets the view of all the movies
        [HttpGet]
        public IActionResult MovieList()
        {
            // Eagerly load the related Category data with each Movie
            var movies = _context.Movies.Include(m => m.Category).ToList();

            return View(movies);
        }

        // gets the view to edit movies
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

        // posts the edited movie into the database
        [HttpPost]
        public IActionResult EditMovie(Movie response)
        {
            // Update the record in the database
            _context.Movies.Update(response);
            // Commit the changes to the database
            _context.SaveChanges();
            // Redirect to the test page
            return RedirectToAction("test");
        }

        // this gets a view to confirm a movie deletion
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            // Fetch the movie from the database
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            // Return the view
            return View("DeleteMovie", recordToDelete);
        }

        // posts the deletion of the movie to the database
        [HttpPost]
        public IActionResult DeleteMovie(Movie response)
        {
            // Remove the record from the database
            _context.Movies.Remove(response);
            // Commit the changes to the database
            _context.SaveChanges();
            // Redirect to the test page
            return RedirectToAction("test");
        }   
    }
}
