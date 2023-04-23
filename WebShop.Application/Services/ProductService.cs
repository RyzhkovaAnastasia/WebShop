using Microsoft.Extensions.Logging;
using WebShop.Core.Exceptions;
using WebShop.Core.Interfaces;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
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

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByConditionAsync(p => p.ProductId == id);

            if (product != null)
            {
                return product;
            }

            _logger.LogError($"Error : {nameof(ProductService)}.{nameof(GetByIdAsync)} - Not found for '{id}' ID");
            throw new ArgumentException("Not found");
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await CheckNameIsNotUnique(product);

            try
            {
                return await _productRepository.CreateAsync(product);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error : {nameof(ProductService)}.{nameof(CreateAsync)} - {exception.Message}");
                throw;
            }
        }

        public async Task<Product> EditAsync(Product product)
        {
            var oldProduct = await GetByIdAsync(product.ProductId);
            await CheckNameIsNotUnique(product);

            try
            {
                product.ProductId = oldProduct.ProductId;
                return await _productRepository.EditAsync(product);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error : {nameof(ProductService)}.{nameof(EditAsync)} - {exception.Message}");
                throw;
            }
        }

        #region privates

        private async Task CheckNameIsNotUnique(Product product)
        {
            var isProductUnique = await _productRepository
                .GetByConditionAsync(p => p.ProductName == product.ProductName && p.ProductId != product.ProductId) == default;

            if (!isProductUnique)
            {
                _logger.LogError($"Error : {nameof(ProductService)}.{nameof(CheckNameIsNotUnique)} - Product name is not unique");
                throw new ModelException("Product name is not unique");
            }
        }

        #endregion
    }
}