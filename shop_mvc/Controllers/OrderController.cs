﻿using Microsoft.AspNetCore.Mvc;
using shop_mvc.Services.Order;

namespace shop_mvc.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService;
        public OrderController(OrderService orderService)
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
        public async Task<IActionResult> Order()
        {
            await orderService.OrderProduct(HttpContext);

            return LocalRedirect("/Home/Index");
        }
    }
}
