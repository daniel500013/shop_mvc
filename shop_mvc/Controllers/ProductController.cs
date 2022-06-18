using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext context;

        public ProductController(ShopDbContext _context)
        {
            context = _context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = context.Product.SingleAsync(x => x.Id == id).Result;

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
                await context.AddAsync(collection);
                await context.SaveChangesAsync();

                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = context.Product.SingleAsync(x => x.Id == id).Result;

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductModel collection)
        {
            if (ModelState.IsValid)
            {
                context.Update(collection);
                await context.SaveChangesAsync();

                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = context.Product.SingleAsync(x => x.Id == id).Result;

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductModel collection)
        {
            var product = context.Product.SingleAsync(x => x.Id == id).Result;

            if (product != null)
            {
                context.Remove(product);
                await context.SaveChangesAsync();

                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
    }
}
