using Microsoft.AspNetCore.Mvc;

namespace shop_mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShopDbContext context;

        public OrderController(ShopDbContext context)
        {
            this.context = context;
        }

        // GET /OrderController/Index
        public async Task<IActionResult> Index(int id)
        {
            var orderProductID = await context.Order.Where(x => x.UserID == id)
                .Select(p => new { p.ProductID, p.Count, p.Id })
                .ToListAsync();

            List<ProductModel> products = new List<ProductModel>();

            for (int i = 0; i < orderProductID.Count(); i++)
            {
                var product = await context.Product.FirstOrDefaultAsync(p => p.Id == orderProductID[i].ProductID);
                product.Count = orderProductID[i].Count;
                product.Id = orderProductID[i].Id;

                products.Add(product);
            }

            return View(products);
        }

        // GET /OrderController/Create
        public async Task<IActionResult> Create(int productID, int userID)
        {
            if (productID != 0 && userID != 0)
            {
                await context.AddAsync(new OrderModel { ProductID = productID, UserID = userID });
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { id = userID });
        }

        // GET /OrderController/Create
        public async Task<IActionResult> Delete (int productID, int userID)
        {
            var order = await context.Order
                .Where(x => x.UserID == userID)
                .Where(p => p.Id == productID)
                .ToListAsync();

            context.Order.Remove(order[0]);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = userID });
        }

        // GET /OrderController/Order
        public async Task<IActionResult> Order(int userID)
        {
            var orders = await context.Order
                .Where(x => x.UserID == userID)
                .ToListAsync();

            for (int i = 0; i < orders.Count; i++)
            {
                context.Order.Remove(orders[i]);

                var product = await context.Product
                    .Where(x => x.Id == orders[i].ProductID)
                    .ToListAsync();

                await context.Bought.AddAsync(
                    new BoughtModel()
                    {
                        Complete = false,
                        productID = orders[i].ProductID,
                        userID = orders[i].UserID,
                        TotalPrice = orders[i].Count * Decimal.ToInt32(product[0].Price)
                    });

                await context.SaveChangesAsync();
            }

            return LocalRedirect("/Home/Index");
        }
    }
}
