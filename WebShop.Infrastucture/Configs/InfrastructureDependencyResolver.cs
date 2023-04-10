using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebShop.Infrastucture.Configs;
using WebShop.Infrastucture.Interfaces;
using WebShop.Infrastucture.Repositories;
using WebShop.Models;

namespace WebShop.Core.Configs
{
    public class InfrastructureDependencyResolver
    {
        public InfrastructureDependencyResolver(IServiceCollection serviceBuilder, string dbConnectionString)
        {
            serviceBuilder.AddTransient<IRepository<Product>, ProductRepository>();
            serviceBuilder.AddTransient<IRepository<Category>, CategoryRepository>();
            serviceBuilder.AddTransient<IRepository<Supplier>, SupplierRepository>();

            if (dbConnectionString != null)
            {
                serviceBuilder.AddDbContext<NorthwindDbContext>(options =>
                    options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(dbConnectionString));
            }
        }
    }
}