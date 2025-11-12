// --- Models/Product.cs ---
// Simple product model used in the store.

namespace FinalBossEnterprize.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool InStock { get; set; }

        public override string ToString()
        {
            var availability = InStock ? "[Available]" : "[Out of stock]";
            return $"{Id}. {Name} — {Price.ToString("C2")} {availability}";
        }
    }
}
