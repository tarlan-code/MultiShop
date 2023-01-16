using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class Category:BaseEntity
    {
        [MinLength(1),MaxLength(30)]
        public double Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
