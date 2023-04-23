using WebShop.Models;

namespace WebShop.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync(int? productNumber = default);
        Task<Product> GetByIdAsync(int id);
        Task<Product> EditAsync(Product product);
        Task<Product> CreateAsync(Product product);
    }
}