using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_mvc.Services.Product;

namespace shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
            
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await Task.Run(() =>
            {
                var productService = new ProductService();
                return productService.GetProduct(id);
            });

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductModel collection)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() =>
                {
                    var productService = new ProductService();
                    return productService.CreateProduct(collection);
                });

                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        //// GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await Task.Run(() =>
            {
                var productService = new ProductService();
                return productService.GetEditProduct(id);
            });

            return View(product);
        }

        //// POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductModel collection)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() =>
                {
                    var productService = new ProductService();
                    return productService.PostEditProduct(id, collection);
                });

                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        //// GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await Task.Run(() =>
            {
                var productService = new ProductService();
                return productService.GetDeleteProduct(id);
            });

            return View(product);
        }

        //// POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductModel collection)
        {
            var isDeleted = await Task.Run(() =>
            {
                var productService = new ProductService();
                return productService.PostDeleteProduct(id, collection);
            });

            if (isDeleted)
            {
                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
    }
}
