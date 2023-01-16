using System.ComponentModel.DataAnnotations;

namespace MultiShop.ViewModels
{
    public class CreateProductVM
    {
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0.00, Double.MaxValue)]
        public double CostPrice { get; set; }
        [Range(0.00, Double.MaxValue)]
        public double SellPrice { get; set; }
        public List<int> CategoryIds { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
      
        public int DiscountId { get; set; }

        public int ProductInfoId { get; set; }
    }
}
