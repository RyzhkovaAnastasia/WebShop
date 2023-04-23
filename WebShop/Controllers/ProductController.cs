using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Exceptions;
using WebShop.Core.Interfaces;
using WebShop.Mappers;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly ProductMapper _productMapper;

        private readonly int _productsOnPage = 0;

        public ProductController(
            IProductService productService,
            ProductMapper productMapper,
            IConfiguration configuration = null)
        {
            _productService = productService;
            _productMapper = productMapper;
            _productsOnPage = configuration.GetValue<int>("Values:ProductsOnPage");
        }

        public async Task<ActionResult> Index()
        {
            if (_productsOnPage <= 0)
            {
                return View(await _productService.GetAsync());
            }

            var products = await _productService.GetAsync(_productsOnPage);

            return View(products);
        }

        public async Task<ActionResult> CreateAsync()
        {
            var productView = await _productMapper.ProductMapToProductDetailsView(new Product());
            return View(productView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ProductDetailsView productView)
        {
            try
            {
                var product = _productMapper.ProductDetailsViewMapToProduct(productView);
                await _productService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch (ModelException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(productView);
            }
        }

        public async Task<ActionResult> EditAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productView = await _productMapper.ProductMapToProductDetailsView(product);

            return View(productView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                await _productService.EditAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch (ModelException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                var productView = await _productMapper.ProductMapToProductDetailsView(product);
                return View(productView);
            }
        }
    }
}