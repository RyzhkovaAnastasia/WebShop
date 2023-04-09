using WebShop.Core.Interfaces;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Core.Services
{
    public class SupplierService : ISupplierService
    {
        readonly private IRepository<Supplier> _supplierRepository;

        public SupplierService(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAsync()
        {
            var suppliers = await _supplierRepository.GetAsync();

            if (suppliers != null)
            {
                return suppliers;
            }

            return new List<Supplier>();
        }
    }
}