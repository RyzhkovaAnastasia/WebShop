using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Interfaces;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly int _productsOnPage = 0;

        public ProductController(IProductService productService, IConfiguration configuration = null)
        {
            _productService = productService;
            _productsOnPage = configuration.GetValue<int>("Values:ProductsOnPage");
        }

        public async Task<ActionResult> Index()
        {
            if (_productsOnPage == 0)
            {
                return View(await _productService.GetAsync());
            }
            else
            {
                var products = await _productService.GetAsync();
                var productsOnPage = products.Take(Math.Abs(_productsOnPage));

                return View(productsOnPage);
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}