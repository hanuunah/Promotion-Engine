namespace Promotion.Engine.Domain.Models
{
    public class SkuType
    {
        public static readonly SkuType A = new SkuType(1, "A");
        public static readonly SkuType B = new SkuType(2, "B");
        public static readonly SkuType C = new SkuType(3, "C");
        public static readonly SkuType D = new SkuType(4, "D");

        public string Value { get; }
        public int Id { get; }

        public SkuType(int id, string value)
        {
            Id = id;
            Value = value;
        }

    }
}
