using Microsoft.EntityFrameworkCore;
using WebShop.Infrastucture.Configs;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Infrastucture.Repositories
{
    internal class ProductRepository : IRepository<Product>
    {
        readonly private NorthwindDbContext _context;
        public ProductRepository(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}