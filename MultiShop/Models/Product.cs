using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class Product:BaseEntity
    {
        [MinLength(1),MaxLength(50)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0.00, 999999)]
        public double CostPrice { get; set; }
        [Range(0.00, 999999)]
        public double SellPrice { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public int? DiscountId { get; set; }
		public Discount? Discount { get; set; }

		public int ProductInfoId { get; set; }
		public ProductInfo? ProductInfo { get; set; }

		public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }
        public ICollection<ProductSize>? ProductSizes { get; set; }

    }
}
