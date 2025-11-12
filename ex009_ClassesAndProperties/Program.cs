// --- Lesson 09: Classes and Properties ---
// Demonstrates defining classes, fields, constructors, and properties.
// In short: teaching code how to describe itself politely.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Creating objects ---
        Console.WriteLine("Instantiating product objects. Because abstract thought needs concrete examples.");
        Product laptop = new Product("Laptop", 1299.99, 10);
        Product phone = new Product("Smartphone", 899.49, 5);

        Console.WriteLine();
        Console.WriteLine(laptop.GetDetails());
        Console.WriteLine(phone.GetDetails());

        Console.WriteLine();

        // --- Section: Using properties ---
        Console.WriteLine("Adjusting stock via property access...");
        laptop.Stock -= 2;
        phone.Stock += 1;

        Console.WriteLine($"Laptop stock left: {laptop.Stock}");
        Console.WriteLine($"Phone stock left: {phone.Stock}");

        Console.WriteLine();

        // --- Section: Demonstrating constructor overload ---
        Product unnamed = new Product();
        Console.WriteLine(unnamed.GetDetails());
        Console.WriteLine();

        // --- Section: Required property example ---
        var user = new User { Username = "john_doe", Email = "john@example.com" };
        Console.WriteLine($"User created: {user.Username} ({user.Email})");

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Objects destroyed. Memory relieved.");

        // Everything is an object, even your confusion.
    }
}

// --- Section: Product class definition ---
public class Product
{
    // --- Fields ---
    private string name;
    private double price;
    private int stock;

    // --- Constructors ---
    public Product()
    {
        name = "Undefined";
        price = 0.0;
        stock = 0;
    }

    public Product(string name, double price, int stock)
    {
        this.name = name;
        this.price = price;
        this.stock = stock;
    }

    // --- Properties ---
    public string Name
    {
        get => name;
        set => name = value;
    }

    public double Price
    {
        get => price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative.");
            price = value;
        }
    }

    public int Stock
    {
        get => stock;
        set => stock = value < 0 ? 0 : value;
    }

    // --- Methods ---
    public string GetDetails()
    {
        return $"Product: {Name}, Price: {Price:C2}, Stock: {Stock}";
    }
}

// --- Section: User class with required properties ---
public class User
{
    public required string Username { get; init; }
    public required string Email { get; init; }
}
