using shop_mvc.Services.Order;
using Xunit;

namespace shop_mvc.Tests
{
    public class OrderServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GerResult_ForValidModel_ReturnsCorrectResult(int id)
        {
            OrderService orderService = new OrderService();

            var productsList = await orderService.GetIndexOrderProducts(id);

            Assert.NotNull(productsList);
        }
    }
}
