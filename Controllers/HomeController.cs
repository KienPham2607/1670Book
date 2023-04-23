using _1670Book.Data;
using _1670Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _1670Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var products = from prd in _context.Products select prd;

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }

            var categories = _context.Category.ToList();
            ViewBag.Categories = categories;
            ViewBag.Products = products;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}