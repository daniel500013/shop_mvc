using Microsoft.AspNetCore.Mvc;
using shop_mvc.Models;
using System.Diagnostics;

namespace shop_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext _shopContext;

        public HomeController(ILogger<HomeController> logger, ShopDbContext shopContext)
        {
            _logger = logger;
            _shopContext = shopContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _shopContext.Product.ToListAsync();

            return View(products);
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