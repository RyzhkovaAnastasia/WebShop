using Microsoft.Extensions.DependencyInjection;
using WebShop.Core.Interfaces;
using WebShop.Core.Services;

namespace WebShop.Core.Configs
{
    public class CoreDependencyResolver
    {
        public CoreDependencyResolver(IServiceCollection serviceBuilder) 
        {
            _ = new InfrastructureDependencyResolver(serviceBuilder);

            serviceBuilder.AddTransient<IProductService, ProductService>();
            serviceBuilder.AddTransient<ICategoryService, CategoryService>();
            serviceBuilder.AddTransient<ISupplierService, SupplierService>();
        }
    }
}