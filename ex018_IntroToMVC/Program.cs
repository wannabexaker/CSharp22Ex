// --- Lesson 18: Intro to MVC ---
// Demonstrates the Model-View-Controller pattern in a simplified console simulation.
// Giannis Pythonopoulos finally discovers architecture, but it’s too late to turn back.

using System;
using System.Collections.Generic;

// --- Section: Model ---
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double Price { get; set; }

    public override string ToString() => $"{Id}. {Name} - {Price:C2}";
}

// --- Section: View ---
public static class ProductView
{
    public static void ShowAll(List<Product> products)
    {
        Console.WriteLine("=== Product List ===");
        foreach (var p in products)
            Console.WriteLine(p);
        Console.WriteLine("====================");
    }

    public static void ShowDetails(Product product)
    {
        Console.WriteLine($"Product Details:");
        Console.WriteLine($"ID: {product.Id}");
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price:C2}");
        Console.WriteLine();
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine($"[Info] {message}");
    }
}

// --- Section: Controller ---
public class ProductController
{
    private readonly List<Product> products = new();

    public ProductController()
    {
        // Pretend this came from a database.
        products.Add(new Product { Id = 1, Name = "Mechanical Keyboard", Price = 89.99 });
        products.Add(new Product { Id = 2, Name = "Wireless Mouse", Price = 59.49 });
        products.Add(new Product { Id = 3, Name = "Monitor 27\"", Price = 229.00 });
        products.Add(new Product { Id = 4, Name = "C# Mug", Price = 15.00 });
    }

    public void ListProducts()
    {
        ProductView.ShowAll(products);
    }

    public void ShowProduct(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product != null)
            ProductView.ShowDetails(product);
        else
            ProductView.ShowMessage("Product not found. Probably discontinued.");
    }

    public void AddProduct(string name, double price)
    {
        int nextId = products.Count + 1;
        products.Add(new Product { Id = nextId, Name = name, Price = price });
        ProductView.ShowMessage($"Product '{name}' added successfully.");
    }
}

// --- Section: Program (entry point) ---
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Console MVC Demo — starring Giannis Pythonopoulos.");
        ProductController controller = new();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. List Products");
            Console.WriteLine("2. View Product Details");
            Console.WriteLine("3. Add Product");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    controller.ListProducts();
                    break;
                case "2":
                    Console.Write("Enter Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        controller.ShowProduct(id);
                    else
                        ProductView.ShowMessage("Invalid ID. Try again, Giannis.");
                    break;
                case "3":
                    Console.Write("Enter product name: ");
                    string? name = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    if (double.TryParse(Console.ReadLine(), out double price))
                        controller.AddProduct(name ?? "Unnamed", price);
                    else
                        ProductView.ShowMessage("Invalid price input.");
                    break;
                case "4":
                    Console.WriteLine("Exiting MVC simulation. Layers collapsing...");
                    return;
                default:
                    Console.WriteLine("Unknown choice. Controller ignored your request.");
                    break;
            }
        }
    }
}
