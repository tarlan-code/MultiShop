using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class ProductSize:BaseEntity
    {
        [MinLength(1), MaxLength(30)]
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product? Product{ get; set; }
    }
}
