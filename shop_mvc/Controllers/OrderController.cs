using Microsoft.AspNetCore.Mvc;
using shop_mvc.Services.Order;

namespace shop_mvc.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET /OrderController/Index
        public async Task<IActionResult> Index(int id)
        {
            var products = await orderService.GetIndexOrderProducts(id);

            return View(products);
        }

        // GET /OrderController/Create
        public async Task<IActionResult> Create(int productID, int userID)
        {
            await orderService.CreateProduct(productID, userID);

            return RedirectToAction("Index", new { id = userID });
        }

        // GET /OrderController/Create
        public async Task<IActionResult> Delete (int productID, int userID)
        {
            await orderService.DeleteProduct(productID, userID);

            return RedirectToAction("Index", new { id = userID });
        }

        // GET /OrderController/Order
        public async Task<IActionResult> Order(int userID)
        {
            await orderService.OrderProduct(userID);

            return LocalRedirect("/Home/Index");
        }
    }
}
