namespace shop_mvc.Services.Product
{
    public interface IProductService
    {
        Task<ProductModel> GetProduct(int id);
        Task CreateProduct(ProductModel collection);
        Task<ProductModel> GetEditProduct(int id);
        Task PostEditProduct(int id, ProductModel collection);
        Task<ProductModel> GetDeleteProduct(int id);
        Task<bool> PostDeleteProduct(int id, ProductModel collection);
    }
}
