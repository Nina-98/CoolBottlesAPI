namespace CoolBottlesAPI.Models.DB
{
    public class Bottle
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Amount { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
