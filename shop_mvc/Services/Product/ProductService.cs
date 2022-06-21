namespace shop_mvc.Services.Product
{
    public class ProductService
    {
        private ShopDbContext context;

        public ProductService(ShopDbContext context)
        {
            this.context = context;
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            var product = await context.Product.SingleAsync(x => x.Id == id);
            return product;
        }

        public async Task CreateProduct(ProductModel collection)
        {
            await context.AddAsync(collection);
            await context.SaveChangesAsync();
        }

        public async Task<ProductModel> GetEditProduct(int id)
        {
            var product = await context.Product.SingleAsync(x => x.Id == id);

            return product;
        }

        public async Task PostEditProduct(int id, ProductModel collection)
        {
            context.Update(collection);
            await context.SaveChangesAsync();
        }

        public async Task<ProductModel> GetDeleteProduct(int id)
        {
            var product = await context.Product.SingleAsync(x => x.Id == id);

            return product;
        }

        public async Task<bool> PostDeleteProduct(int id, ProductModel collection)
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
