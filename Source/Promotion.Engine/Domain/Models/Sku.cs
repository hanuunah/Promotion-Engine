namespace PromotionEngine.Domain.Models
{
    public class Sku
    {
        public Sku(string id, double price)
        {
            Id = id;
            Price = price;
        }
        public string Id { get;}
        public double Price { get;  }
    }
}
