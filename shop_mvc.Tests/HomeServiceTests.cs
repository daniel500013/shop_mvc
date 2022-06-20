using shop_mvc.Logic.Home;
using shop_mvc.Models;

namespace shop_mvc.Tests
{
    public class HomeServiceTests
    {
        [Fact]
        public async Task GerResult_ForValidModel_ReturnsCorrectResult()
        {
            HomeService homeService = new HomeService();

            var product = await homeService.IndexGetAllProducts();

            Assert.NotNull(product);
        }
    }
}