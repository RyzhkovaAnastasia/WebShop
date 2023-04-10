using Microsoft.Extensions.DependencyInjection;
using WebShop.Core.Interfaces;
using WebShop.Core.Services;

namespace WebShop.Core.Configs
{
    public class CoreDependencyResolver
    {
        public CoreDependencyResolver(IServiceCollection serviceBuilder, string dbConnectionString)
        {
            _ = new InfrastructureDependencyResolver(serviceBuilder, dbConnectionString);

            serviceBuilder.AddTransient<IProductService, ProductService>();
            serviceBuilder.AddTransient<ICategoryService, CategoryService>();
            serviceBuilder.AddTransient<ISupplierService, SupplierService>();
        }
    }
}