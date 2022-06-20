using shop_mvc.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_mvc.Tests
{
    public class ProductServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GerResult_ForSelectedProduct_ReturnsCorrectResult(int id)
        {
            ProductService productService = new ProductService();

            var product = await productService.GetProduct(id);

            Assert.NotNull(product);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GerResult_ForEditedProduct_ReturnsCorrectResult(int id)
        {
            ProductService productService = new ProductService();

            var product = await productService.GetEditProduct(id);

            Assert.NotNull(product);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GerResult_ForDeleteProduct_ReturnsCorrectResult(int id)
        {
            ProductService productService = new ProductService();

            var product = await productService.GetDeleteProduct(id);

            Assert.NotNull(product);
        }
    }
}
