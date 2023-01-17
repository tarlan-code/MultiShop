namespace MultiShop.Models
{
	public class BaseAccountableEntity:BaseEntity
	{
		public DateTime? CreatedAt { get; set; }	
		public DateTime? ModifiedAt { get; set; }
		public string CreatedBy { get; set; }
	}
}
