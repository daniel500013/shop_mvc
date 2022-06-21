namespace shop_mvc.Services.Order
{
    public class OrderService
    {
        private ShopDbContext context;
        public OrderService(ShopDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductModel>> GetIndexOrderProducts(int id)
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

            return products;
        }

        public async Task CreateProduct(int productID, int userID)
        {
            if (productID != 0 && userID != 0)
            {
                await context.AddAsync(new OrderModel { ProductID = productID, UserID = userID });
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int productID, int userID)
        {
            var order = await context.Order
                                .Where(x => x.UserID == userID)
                                .Where(p => p.Id == productID)
                                .ToListAsync();

            context.Order.Remove(order[0]);
            await context.SaveChangesAsync();
        }

        public async Task OrderProduct(HttpContext httpContext)
        {
            int userID;

            var userIDString = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int.TryParse(userIDString, out userID);

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
        }
    }
}
