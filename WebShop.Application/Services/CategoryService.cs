using WebShop.Core.Interfaces;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var categories = await _categoryRepository.GetAsync();

            if (categories != null)
            {
                return categories;
            }

            return new List<Category>();
        }
    }
}