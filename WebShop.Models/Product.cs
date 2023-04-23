using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is requierd")]
        [MaxLength(40, ErrorMessage = "Name must be less then 40 characters")]
        public string? ProductName { get; set; }

        [DisplayName("Quantity per unit")]
        [MaxLength(20, ErrorMessage = "Name must be less then 20 characters")]
        public string? QuantityPerUnit { get; set; }

        [DisplayName("Unit price")]
        public decimal? UnitPrice { get; set; }

        [DisplayName("Units in stock")]
        public short? UnitsInStock { get; set; }

        [DisplayName("Units on order")]
        public short? UnitsOnOrder { get; set; }

        [DisplayName("Reorder level")]
        public short? ReorderLevel { get; set; }

        [DisplayName("Discontinued")]
        [Required(ErrorMessage = "Discontinued is requierd")]
        public bool Discontinued { get; set; } = false;

        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}