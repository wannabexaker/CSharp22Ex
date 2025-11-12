// --- Lesson 04: User Input and Conversion ---
// Demonstrates reading user input, parsing values, and simple calculations.

using System;
using System.Globalization;



public class Program
{

    public static void Main(string[] args)
    {
        // --- Section: Enable Unicode output ---
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // --- Section: Basic input ---
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter your age: ");
        string ageInput = Console.ReadLine();

        // --- Section: Convert and validate ---
        int age = int.Parse(ageInput);
        Console.WriteLine();
        Console.WriteLine($"Hello {userName}, next year you’ll be {age + 1}.");
        Console.WriteLine();

        // --- Section: Numeric input and math ---
        Console.Write("Enter the price of one item: ");
        double price = double.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine() ?? "0");

        double total = price * quantity;
        Console.WriteLine($"Total cost: {total} €");
        Console.WriteLine();

        // --- Section: Simple feedback ---
        if (total > 100)
            Console.WriteLine("Big spender detected.");
        else
            Console.WriteLine("Reasonable purchase.");

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Input dismissed. Silence restored.");

        // Input is just data waiting to be misunderstood.
    }
}
