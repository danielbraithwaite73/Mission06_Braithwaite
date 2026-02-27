using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Braithwaite.Models;

namespace Mission06_Braithwaite.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationContext _context;

        public HomeController(ApplicationContext temp) 
        { 
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Application());
        }

        [HttpPost] // The form method to accept the data from the form and add it to the database
        public IActionResult Form(Application response)
        {
            ViewBag.Categories = _context.Categories.ToList();
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                // This clears the form and stays on the page
                ModelState.Clear();
                ViewBag.SuccessMessage = "Movie added successfully!";
                return View("Form", new Application());
            }

            // If validation fails, return the Form view with the current data
            return View("Form", response);
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = _context.Movies
                .Include(x => x.Category) // This is how we include the related data form the category table.
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id); // Only 1 record is expected.

            ViewBag.Categories = _context.Categories.ToList();

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            if (ModelState.IsValid) // Makes sure that they still have the required fields after edit.
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }
            ViewBag.Categories = _context.Categories.ToList();

            return View("Form", updatedInfo);
        }

        // No deletion screen as part of the requirments so our get request is what deletes the record.
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
