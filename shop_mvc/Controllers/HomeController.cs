using Microsoft.AspNetCore.Mvc;
using shop_mvc.Logic.Home;
using shop_mvc.Models;
using System.Diagnostics;

namespace shop_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var products = await Task.Run(() =>
            {
                HomeService hl = new HomeService();
                return hl.IndexGetAllProducts();
            });

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}