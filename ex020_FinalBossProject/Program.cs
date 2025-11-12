// --- Lesson 20: Final Boss Project ---
// Complete integration of everything learned so far.
// MVC, Razor-style output, async simulation, LINQ queries, logging, and sarcasm.
// Giannis Pythonopoulos finally ships a working application. Probably.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// --- Section: Models ---
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public bool InStock { get; set; }

    public override string ToString() => $"{Id}. {Name} — {Price:C2} {(InStock ? "[Available]" : "[Out of stock]")}";
}

public class Order
{
    public int Id { get; set; }
    public List<Product> Items { get; } = new();
    public double Total => Items.Sum(p => p.Price);
    public DateTime CreatedAt { get; } = DateTime.Now;
}

// --- Section: Repository ---
public static class DataRepository
{
    private static readonly List<Product> products = new()
    {
        new Product { Id = 1, Name = "Keyboard", Price = 89.99, InStock = true },
        new Product { Id = 2, Name = "Mouse", Price = 49.99, InStock = true },
        new Product { Id = 3, Name = "Monitor", Price = 199.00, InStock = false },
        new Product { Id = 4, Name = "Headphones", Price = 129.50, InStock = true }
    };

    private static readonly List<Order> orders = new();

    public static Task<List<Product>> GetProductsAsync() => Task.FromResult(products);

    public static Task<List<Order>> GetOrdersAsync() => Task.FromResult(orders);

    public static Task AddOrderAsync(Order order)
    {
        orders.Add(order);
        Logger.Log($"Order #{order.Id} created with {order.Items.Count} item(s). Total: {order.Total:C2}");
        return Task.CompletedTask;
    }
}

// --- Section: Controller ---
public class StoreController
{
    public async Task DisplayProductsAsync()
    {
        var products = await DataRepository.GetProductsAsync();
        RazorView.RenderProductList(products);
    }

    public async Task CreateOrderAsync(params int[] productIds)
    {
        var allProducts = await DataRepository.GetProductsAsync();
        var orderItems = allProducts.Where(p => productIds.Contains(p.Id) && p.InStock).ToList();

        if (!orderItems.Any())
        {
            RazorView.RenderMessage("No valid products selected. Giannis shakes his head silently.");
            return;
        }

        var order = new Order { Id = new Random().Next(1000, 9999) };
        order.Items.AddRange(orderItems);

        await DataRepository.AddOrderAsync(order);
        RazorView.RenderOrderConfirmation(order);
    }

    public async Task ShowOrdersAsync()
    {
        var orders = await DataRepository.GetOrdersAsync();
        RazorView.RenderOrderList(orders);
    }
}

// --- Section: View (Razor simulation) ---
public static class RazorView
{
    public static void RenderProductList(List<Product> products)
    {
        Console.WriteLine("=== Product Catalog ===");
        foreach (var p in products)
            Console.WriteLine(p);
        Console.WriteLine("=======================");
    }

    public static void RenderOrderConfirmation(Order order)
    {
        Console.WriteLine($"Order #{order.Id} created on {order.CreatedAt}");
        foreach (var p in order.Items)
            Console.WriteLine($" - {p.Name} ({p.Price:C2})");
        Console.WriteLine($"Total: {order.Total:C2}");
        Console.WriteLine("Thank you for shopping with Pythonopoulos Store.");
    }

    public static void RenderOrderList(List<Order> orders)
    {
        Console.WriteLine("=== Order History ===");
        if (!orders.Any())
        {
            Console.WriteLine("No orders yet. Economy saved.");
            return;
        }

        foreach (var o in orders)
            Console.WriteLine($"#{o.Id} — {o.Items.Count} items — {o.Total:C2} — {o.CreatedAt}");
    }

    public static void RenderMessage(string message)
    {
        Console.WriteLine($"[System] {message}");
    }
}

// --- Section: Logger ---
public static class Logger
{
    private static readonly string path = "finalboss_log.txt";

    public static void Log(string message)
    {
        string entry = $"[{DateTime.Now}] {message}\n";
        File.AppendAllText(path, entry, Encoding.UTF8);
    }
}

// --- Section: Program Entry ---
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("=== FINAL BOSS PROJECT ===");
        Console.WriteLine("Giannis Pythonopoulos presents: MVC meets async in one terminal.");
        StoreController controller = new();

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Create Order");
            Console.WriteLine("3. View Orders");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    await controller.DisplayProductsAsync();
                    break;
                case "2":
                    Console.Write("Enter product IDs (comma-separated): ");
                    string? idsInput = Console.ReadLine();
                    if (idsInput != null)
                    {
                        int[] ids = idsInput
                            .Split(',')
                            .Select(s => int.TryParse(s.Trim(), out var id) ? id : -1)
                            .Where(id => id > 0)
                            .ToArray();
                        await controller.CreateOrderAsync(ids);
                    }
                    break;
                case "3":
                    await controller.ShowOrdersAsync();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    RazorView.RenderMessage("Invalid choice. The controller refuses to cooperate.");
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Exiting application...");
        Console.WriteLine("Logs saved. Sanity questionable.");

        // Software completed. Humanity not.
    }
}
