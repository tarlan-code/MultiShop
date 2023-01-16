namespace MultiShop.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string ButtonUrl { get; set; }
        public string ButtonText { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}
