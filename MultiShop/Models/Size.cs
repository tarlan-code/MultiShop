using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
	public class Size:BaseEntity
	{
		[MinLength(1), MaxLength(30)]
		public string Name { get; set; }
		public ICollection<ProductSize> ProductSizes { get; set; }
	}
}
