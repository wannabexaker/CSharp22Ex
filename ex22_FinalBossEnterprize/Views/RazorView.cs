// --- Views/RazorView.cs ---
// Console-based "view" layer that simulates Razor-like rendering.

using System;
using System.Collections.Generic;
using FinalBossEnterprize.Models;
using FinalBossEnterprize.Utilities;

namespace FinalBossEnterprize.Views
{
    public static class RazorView
    {
        public static void RenderProductList(IEnumerable<Product> products)
        {
            Console.WriteLine("=== Product Catalog ===");
            foreach (var p in products)
            {
                Console.WriteLine($" - {p.Name.PadRight(20)} {p.Price.ToCurrency()} {(p.InStock ? "[Available]" : "[Out]")}");
            }
            Console.WriteLine("=======================");
            Console.WriteLine();
        }

        public static void RenderOrderDetails(Order order)
        {
            Console.WriteLine($"Order #{order.Id} — created at {order.CreatedAt}");
            foreach (var item in order.Items)
            {
                Console.WriteLine($" * {item.Name} ({item.Price.ToCurrency()})");
            }
            Console.WriteLine($"Total: {order.Total.ToCurrency()}");
            Console.WriteLine();
        }

        public static void RenderOrderList(IEnumerable<Order> orders)
        {
            Console.WriteLine("=== Order History ===");
            bool any = false;
            foreach (var o in orders)
            {
                any = true;
                Console.WriteLine($"#{o.Id} — {o.Items.Count} item(s) — {o.Total.ToCurrency()} — {o.CreatedAt}");
            }

            if (!any)
            {
                Console.WriteLine("No orders found. The economy is stable.");
            }

            Console.WriteLine("=======================");
            Console.WriteLine();
        }

        public static void RenderMessage(string message)
        {
            Console.WriteLine($"[System] {message}");
        }
    }
}
