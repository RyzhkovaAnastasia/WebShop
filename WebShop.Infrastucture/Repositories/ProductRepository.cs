using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebShop.Infrastucture.Configs;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Infrastucture.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly NorthwindDbContext _context;
        public ProductRepository(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> CreateAsync(Product newEntity)
        {
            var product = await _context.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return product.Entity;
        }

        public async Task<Product> EditAsync(Product newEntity)
        {
            _context.Update(newEntity);
            await _context.SaveChangesAsync();

            return newEntity;
        }

        public async Task<Product> GetByConditionAsync(Expression<Func<Product, bool>> condition)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(condition);
        }

        public IEnumerable<Product> GetByProductNumber(int productNumber)
        {
            return _context.Products.OrderByDescending(p => p.ProductId).Take(Math.Abs(productNumber));
        }
    }
}