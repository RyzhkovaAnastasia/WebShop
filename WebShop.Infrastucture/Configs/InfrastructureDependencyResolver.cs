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
        public InfrastructureDependencyResolver(IServiceCollection serviceBuilder) 
        {
            serviceBuilder.AddTransient<IRepository<Product>, ProductRepository>();
            serviceBuilder.AddTransient<IRepository<Category>, CategoryRepository>();
            serviceBuilder.AddTransient<IRepository<Supplier>, SupplierRepository>();

            serviceBuilder.AddDbContext<NorthwindDbContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;"));
        }
    }
}