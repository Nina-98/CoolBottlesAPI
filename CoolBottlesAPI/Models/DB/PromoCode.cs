namespace CoolBottlesAPI.Models.DB
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = "percent"; // "percent" or "amount"
        public double Value { get; set; }
        public DateTime Expiration { get; set; }
        public bool Active { get; set; } = true;
    }
}
