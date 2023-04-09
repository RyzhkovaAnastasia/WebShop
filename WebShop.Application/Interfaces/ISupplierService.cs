using WebShop.Models;

namespace WebShop.Core.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAsync();
    }
}