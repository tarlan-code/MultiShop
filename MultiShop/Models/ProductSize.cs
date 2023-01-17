using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class ProductSize:BaseEntity
    {
        public int SizeiId { get; set; }
        public Size Size { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get; set; }
    }
}
