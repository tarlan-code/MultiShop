using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class Product:BaseEntity
    {
        [MinLength(1),MaxLength(50)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0.00, Double.MaxValue)]
        public double CostPrice { get; set; }
        [Range(0.00, Double.MaxValue)]
        public double SellPrice { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }
        public ICollection<ProductSize>? ProductSizes { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public int ProductInfoId { get; set; }
        public ProductInfo? ProductInfo { get; set; }


    }
}
