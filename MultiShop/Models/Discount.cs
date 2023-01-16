using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class Discount:BaseEntity
    {
        public string Name { get; set; }
        [Range(0.00,100)]
        public double DiscountPercent { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
