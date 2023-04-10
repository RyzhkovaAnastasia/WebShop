using WebShop.Core.Interfaces;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var products = await _productRepository.GetAsync();

            if (products != null)
            {
                return products;
            }

            return new List<Product>();
        }
    }
}