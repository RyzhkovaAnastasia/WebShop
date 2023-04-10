using Microsoft.EntityFrameworkCore;
using WebShop.Infrastucture.Configs;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Infrastucture.Repositories
{
    internal class SupplierRepository : IRepository<Supplier>
    {
        private readonly NorthwindDbContext _context;
        public SupplierRepository(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
    }
}