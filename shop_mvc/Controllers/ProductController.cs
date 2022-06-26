using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_mvc.Services.Product;

namespace shop_mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var product = await productService.GetProduct(id);

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
                await productService.CreateProduct(collection);

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
            var product = await productService.GetEditProduct(id);

            return View(product);
        }

        //// POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductModel collection)
        {
            if (ModelState.IsValid)
            {
                await productService.PostEditProduct(id, collection);

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
            var product = await productService.GetDeleteProduct(id);

            return View(product);
        }

        //// POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductModel collection)
        {
            var isDeleted = await productService.PostDeleteProduct(id, collection);

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
