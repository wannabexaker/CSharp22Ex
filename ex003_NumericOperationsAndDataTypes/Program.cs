// --- Lesson 03: Numeric Operations and Data Types ---
// Demonstrates arithmetic, parsing, and type conversion.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Integer arithmetic ---
        int a = 10;
        int b = 3;

        Console.WriteLine($"Addition: {a + b}");
        Console.WriteLine($"Subtraction: {a - b}");
        Console.WriteLine($"Multiplication: {a * b}");
        Console.WriteLine($"Division (integer): {a / b}");
        Console.WriteLine($"Remainder: {a % b}");
        Console.WriteLine();

        // --- Section: Floating-point arithmetic ---
        double x = 10.0;
        double y = 3.0;
        Console.WriteLine($"Division (double): {x / y}");
        Console.WriteLine($"Rounded result: {Math.Round(x / y, 2)}");
        Console.WriteLine();

        // --- Section: Parsing from string ---
        string inputNumber = "42";
        int parsed = int.Parse(inputNumber);
        Console.WriteLine($"Parsed number + 8 = {parsed + 8}");
        Console.WriteLine();

        // --- Section: Type casting ---
        double price = 19.99;
        int roundedPrice = (int)price;
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"After casting to int: {roundedPrice}");
        Console.WriteLine();

        // --- Section: Combined calculation ---
        double quantity = 3;
        double total = price * quantity;
        Console.WriteLine($"Total cost: {total} €");

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Numbers fade. Logic remains.");

        // Precision is optional until someone checks your math.
    }
}
