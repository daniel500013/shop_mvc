using Microsoft.AspNetCore.Mvc;
using shop_mvc.Logic.Home;
using shop_mvc.Models;
using shop_mvc.Services.Home;
using System.Diagnostics;

namespace shop_mvc.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HomeService homeService)
        {
            _logger = logger;
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await homeService.IndexGetAllProducts();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}