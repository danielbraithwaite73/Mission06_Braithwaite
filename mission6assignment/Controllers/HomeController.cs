using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost] // Sets up the form method to accept the data from the form and add it to the database
        public IActionResult Form(Application response)
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
