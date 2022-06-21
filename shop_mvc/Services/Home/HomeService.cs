using shop_mvc.Services.Home;

namespace shop_mvc.Logic.Home
{
    public class HomeService
    {
        private readonly ShopDbContext context;

        public HomeService(ShopDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductModel>> IndexGetAllProducts()
        {
            var products = await context.Product.ToListAsync();
            return products;
        }
    }
}
