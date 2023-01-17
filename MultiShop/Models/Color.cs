using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
	public class Color:BaseEntity
	{
		[MinLength(1), MaxLength(30)]
		public string Name { get; set; }
		public ICollection<ProductColor> ProductColors { get; set; }
	}
}
