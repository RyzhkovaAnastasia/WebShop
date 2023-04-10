using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Quantity per unit")]
        public string QuantityPerUnit { get; set; }

        [DisplayName("Unit price")]
        public decimal? UnitPrice { get; set; }

        [DisplayName("Units in stock")]
        public short? UnitsInStock { get; set; }

        [DisplayName("Units on order")]
        public short? UnitsOnOrder { get; set; }

        [DisplayName("Reorder level")]
        public short? ReorderLevel { get; set; }

        [DisplayName("Discontinued")]
        public bool? Discontinued { get; set; }

        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}