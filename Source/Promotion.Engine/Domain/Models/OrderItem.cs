namespace PromotionEngine.Domain.Models
{
    public class OrderItem
    {
        public OrderItem(int id, Sku sku, int quantity)
        {
            Id = id;
            Sku = sku;
            Quantity = quantity;
        }

        public int Id { get; }
        public Sku Sku { get; }
        public int Quantity { get; }
        public double Price { get; set; }
    }
}
