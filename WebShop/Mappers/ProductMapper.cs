using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Core.Interfaces;
using WebShop.Models;

namespace WebShop.Mappers
{
    public class ProductMapper
    {
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;

        public ProductMapper(
            ISupplierService supplierService,
            ICategoryService categoryService)
        {
            _supplierService = supplierService;
            _categoryService = categoryService;
        }

        public async Task<ProductDetailsView> ProductMapToProductDetailsView(Product product)
        {
            return new ProductDetailsView
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                Suppliers = (await _supplierService.GetAsync()).Select(s => new SelectListItem()
                {
                    Value = s.SupplierId.ToString(),
                    Text = s.CompanyName
                }),

                Categories = (await _categoryService.GetAsync()).Select(c => new SelectListItem()
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
            };
        }

        public Product ProductDetailsViewMapToProduct(ProductDetailsView productView)
        {
            return new Product
            {
                ProductId = productView.ProductId,
                ProductName = productView.ProductName,
                SupplierId = productView.SupplierId,
                CategoryId = productView.CategoryId,
                Discontinued = productView.Discontinued,
                QuantityPerUnit = productView.QuantityPerUnit,
                ReorderLevel = productView.ReorderLevel,
                UnitPrice = productView.UnitPrice,
                UnitsInStock = productView.UnitsInStock,
                UnitsOnOrder = productView.UnitsOnOrder
            };
        }
    }
}
