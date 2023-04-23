using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShop.Models
{
    public class ProductDetailsView : Product
    {
        public IEnumerable<SelectListItem> Suppliers { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}