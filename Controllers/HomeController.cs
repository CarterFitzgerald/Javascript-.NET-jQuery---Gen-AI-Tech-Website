using Final_Assignment_Carter_Fitzgerald.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Final_Assignment_Carter_Fitzgerald.Data;

namespace Final_Assignment_Carter_Fitzgerald.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Console.WriteLine("Index action started.");

                var genAIsList = _context.GenAIs.ToList();
                int numberOfItems = genAIsList.Count;

                Console.WriteLine($"Number of GenAIs items: {numberOfItems}");

                ViewBag.GenAIsList = genAIsList;
                ViewBag.NumberOfItems = numberOfItems;

                Console.WriteLine("Index action completed.");
                return View(genAIsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return View();
            }
        }

        public IActionResult Jobs()
        {
            return View();
        }

        public IActionResult GenAI()
        {
            return View();
        }

        public IActionResult GenAISites()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LoadHeaderPartial()
        {
            return PartialView("_HeaderPartial");
        }
    }
}