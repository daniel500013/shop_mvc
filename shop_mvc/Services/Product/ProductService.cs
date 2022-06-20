namespace shop_mvc.Services.Product
{
    public class ProductService
    {
        public async Task<ProductModel> GetProduct(int id)
        {
            using (var context = new ShopDbContext())
            {
                var product = await context.Product.SingleAsync(x => x.Id == id);
                return product;
            }
        }

        public async Task CreateProduct(ProductModel collection)
        {
            using (var context = new ShopDbContext())
            {
                await context.AddAsync(collection);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ProductModel> GetEditProduct(int id)
        {
            using (var context = new ShopDbContext())
            {
                var product = await context.Product.SingleAsync(x => x.Id == id);

                return product;
            }
        }

        public async Task PostEditProduct(int id, ProductModel collection)
        {
            using (var context = new ShopDbContext())
            {
                context.Update(collection);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ProductModel> GetDeleteProduct(int id)
        {
            using (var context = new ShopDbContext())
            {
                var product = await context.Product.SingleAsync(x => x.Id == id);

                return product;
            }
        }

        public async Task<bool> PostDeleteProduct(int id, ProductModel collection)
        {
            using (var context = new ShopDbContext())
            {
                var product = await context.Product.SingleAsync(x => x.Id == id);

                if (product != null)
                {
                    context.Remove(product);
                    await context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
