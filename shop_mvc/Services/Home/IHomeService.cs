namespace shop_mvc.Services.Home
{
    public interface IHomeService
    {
        Task<List<ProductModel>> IndexGetAllProducts();
    }
}
