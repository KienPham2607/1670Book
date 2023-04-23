using _1670Book.Data;
using _1670Book.Models;
using _1670Book.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _1670Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IHomeRepository homeRepository)
        {
            _logger = logger;
            _context = context;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm = "", int categoryId = 0)
        {
            //var products = _context.Products.ToList();
            //ViewBag.Products = products;

            IEnumerable<Product> products = await _homeRepository.GetProducts(sterm, categoryId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            ProductDisplayModel productModel = new ProductDisplayModel
            {
                Products = products,
                Categories = categories
            };
            return View(productModel);
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