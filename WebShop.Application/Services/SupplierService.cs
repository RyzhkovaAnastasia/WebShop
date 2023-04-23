using Microsoft.Extensions.Logging;
using WebShop.Core.Interfaces;
using WebShop.Infrastucture.Interfaces;
using WebShop.Models;

namespace WebShop.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _supplierRepository;

        private readonly ILogger<SupplierService> _logger;

        public SupplierService(IRepository<Supplier> supplierRepository, ILogger<SupplierService> logger)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
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