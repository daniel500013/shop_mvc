namespace shop_mvc.Logic.Home
{
    public class HomeService
    {
        public async Task<List<ProductModel>> IndexGetAllProducts()
        {
            using (var _shopContext = new ShopDbContext())
            {
                var products = await _shopContext.Product.ToListAsync();
                return products; 
            }
        }
    }
}
