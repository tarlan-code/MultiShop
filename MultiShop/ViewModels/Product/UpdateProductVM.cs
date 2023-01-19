using MultiShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MultiShop.ViewModels
{
    public class UpdateProductVM
    {
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0.00, 999999)]
        public double CostPrice { get; set; }
        [Range(0.00, 999999)]
        public double SellPrice { get; set; }
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
        public int ProductInfoId { get; set; }
        public List<int> SizeIds { get; set; }
        public List<int> ColorIds { get; set; }
				
       
        public IFormFile? CoverImage { get; set; }
        public IEnumerable<IFormFile>? OtherImages { get; set; }
        public IEnumerable<ProductImage>? ProductImages { get; set; }
    }
}
