// --- Lesson 01: System Console Basics ---
// Demonstrates writing, reading, and clearing in the console.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: WriteLine demonstration ---
        Console.WriteLine("Welcome");
        Console.WriteLine("to");
        Console.WriteLine("C# Programming");

        Console.WriteLine(); // Spacing

        // --- Section: Write demonstration ---
        Console.Write("Welcome ");
        Console.Write("to ");
        Console.Write("C# Programming");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Screen cleared. Ready for next output.");

        // Sometimes progress means deleting everything you just said.
    }
}
