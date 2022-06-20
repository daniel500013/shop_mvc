using Microsoft.AspNetCore.Mvc;
using shop_mvc.Services.Order;

namespace shop_mvc.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
            
        }

        // GET /OrderController/Index
        public async Task<IActionResult> Index(int id)
        {
            var products = await Task.Run(() =>
            {
                var orderService = new OrderService();
                return orderService.GetIndexOrderProducts(id);
            });

            return View(products);
        }

        // GET /OrderController/Create
        public async Task<IActionResult> Create(int productID, int userID)
        {
            await Task.Run(() =>
            {
                var orderService = new OrderService();
                return orderService.CreateProduct(productID, userID);
            });

            return RedirectToAction("Index", new { id = userID });
        }

        // GET /OrderController/Create
        public async Task<IActionResult> Delete (int productID, int userID)
        {
            await Task.Run(() =>
            {
                var orderService = new OrderService();
                return orderService.DeleteProduct(productID, userID);
            });

            return RedirectToAction("Index", new { id = userID });
        }

        // GET /OrderController/Order
        public async Task<IActionResult> Order(int userID)
        {
            await Task.Run(() =>
            {
                var orderService = new OrderService();
                return orderService.OrderProduct(userID);
            });

            return LocalRedirect("/Home/Index");
        }
    }
}
