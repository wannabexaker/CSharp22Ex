// --- Lesson 06: Loops and Iterations ---
// Demonstrates for, while, and do-while loops with basic control flow.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: For loop ---
        Console.WriteLine("Counting from 1 to 5:");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Step {i}");
        }

        Console.WriteLine();

        // --- Section: While loop ---
        Console.WriteLine("Countdown:");
        int count = 5;
        while (count > 0)
        {
            Console.WriteLine($"T-minus {count}");
            count--;
        }

        Console.WriteLine("Lift off.");
        Console.WriteLine();

        // --- Section: Do-while loop ---
        string input;
        do
        {
            Console.Write("Type 'exit' to stop: ");
            input = Console.ReadLine()?.Trim().ToLower();
        }
        while (input != "exit");

        Console.WriteLine();
        Console.WriteLine("Program exited by user.");
        Console.WriteLine();

        // --- Section: Loop control ---
        Console.WriteLine("Demonstrating break and continue:");
        for (int i = 1; i <= 10; i++)
        {
            if (i == 3) continue;
            if (i == 8) break;
            Console.WriteLine($"Index: {i}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Loop terminated. Time moves on.");

        // Infinite loops exist. They’re called meetings.
    }
}
