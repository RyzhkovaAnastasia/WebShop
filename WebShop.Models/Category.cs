using System.ComponentModel;

namespace WebShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Category name")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}