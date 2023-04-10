using Microsoft.EntityFrameworkCore;
using WebShop.Infrastucture.Configs;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Infrastucture.Repositories
{
    internal class CategoryRepository : IRepository<Category>
    {
        private readonly NorthwindDbContext _context;
        public CategoryRepository(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}