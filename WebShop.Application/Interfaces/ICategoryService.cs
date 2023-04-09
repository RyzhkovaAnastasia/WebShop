using WebShop.Models;

namespace WebShop.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAsync();
    }
}