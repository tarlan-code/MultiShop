using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class ProductImage:BaseEntity
    {
        
        public string ImgUrl { get; set; }
        public bool IsCover { get; set; }
        public string Alternative { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
