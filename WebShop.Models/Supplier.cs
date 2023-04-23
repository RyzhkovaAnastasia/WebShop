using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        [DisplayName("Company name")]
        public string CompanyName { get; set; }

        [DisplayName("Contact name")]
        public string? ContactName { get; set; }

        [DisplayName("Contact title")]
        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        [DisplayName("Postal code")]
        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        [DisplayName("Home page")]
        public string? HomePage { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}