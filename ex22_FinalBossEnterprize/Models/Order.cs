// --- Models/Order.cs ---
// Order model holding selected products and computed total.

using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalBossEnterprize.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Items { get; } = new();
        public DateTime CreatedAt { get; } = DateTime.Now;

        public double Total => Items.Sum(p => p.Price);
    }
}
