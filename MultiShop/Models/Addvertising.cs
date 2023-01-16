namespace MultiShop.Models
{
    public class Addvertising:BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ButtonUrl { get; set; }
        public string ButtonText { get; set; }
        public string ImageUrl { get; set; }
    }
}
