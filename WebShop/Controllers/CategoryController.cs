using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Interfaces;

namespace WebShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetAsync();
            return View(categories);
        }
    }
}