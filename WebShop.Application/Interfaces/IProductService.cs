using WebShop.Models;

namespace WebShop.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync();
    }
}