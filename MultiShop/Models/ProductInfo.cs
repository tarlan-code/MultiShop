using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class ProductInfo:BaseEntity
    {
        [MinLength(1), MaxLength(30)]
        public string Key { get; set; }
        public string Text { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
