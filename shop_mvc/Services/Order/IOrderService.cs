namespace shop_mvc.Services.Order
{
    public interface IOrderService
    {
        Task<List<ProductModel>> GetIndexOrderProducts(int id);
        Task CreateProduct(int productID, int userID);
        Task DeleteProduct(int productID, int userID);
        Task OrderProduct(HttpContext httpContext);
    }
}
