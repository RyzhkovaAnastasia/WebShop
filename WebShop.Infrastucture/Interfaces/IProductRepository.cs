using System.Linq.Expressions;
using WebShop.Models;

namespace WebShop.Infrastucture.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> CreateAsync(Product product);

        Task<Product> EditAsync(Product product);

        Task<Product> GetByConditionAsync(Expression<Func<Product, bool>> condition);

        IEnumerable<Product> GetByProductNumber(int productNumber);
    }
}