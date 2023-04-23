using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Interfaces;

namespace WebShop.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<ActionResult> Index()
        {
            var suppliers = await _supplierService.GetAsync();
            return View(suppliers);
        }
    }
}