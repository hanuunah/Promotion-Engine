namespace PromotionEngine.Domain.Models
{
    public class PromotionType
    {
        public static readonly PromotionType Type1 = new PromotionType(1, "Type1");
        public static readonly PromotionType Type2 = new PromotionType(2, "Type2");
        public static readonly PromotionType Type3 = new PromotionType(3, "Type3");

        public string Value { get; }
        public int Id { get; }

        public PromotionType(int id, string value)
        {
            Id = id;
            Value = value;
        }

    }
}
