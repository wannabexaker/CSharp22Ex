// --- Lesson 05: Conditional Statements ---
// Demonstrates if, else if, else, and logical operators.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Simple condition ---
        Console.Write("Enter your score (0–100): ");
        int score = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine();

        if (score >= 90)
            Console.WriteLine("Grade: A");
        else if (score >= 75)
            Console.WriteLine("Grade: B");
        else if (score >= 60)
            Console.WriteLine("Grade: C");
        else
            Console.WriteLine("Grade: Fail");

        Console.WriteLine();

        // --- Section: Logical operators ---
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine() ?? "0");

        if (age >= 18 && age <= 65)
            Console.WriteLine("You’re in the working range.");
        else if (age < 18)
            Console.WriteLine("Still in training mode.");
        else
            Console.WriteLine("You’ve reached the debugging phase of life.");

        Console.WriteLine();

        // --- Section: Nested conditions ---
        Console.Write("Enter temperature (°C): ");
        int temp = int.Parse(Console.ReadLine() ?? "0");

        if (temp > 30)
        {
            Console.WriteLine("Hot day detected.");
            if (temp > 40)
                Console.WriteLine("Hardware may throttle soon.");
        }
        else if (temp >= 20)
            Console.WriteLine("Comfort zone.");
        else
            Console.WriteLine("Cold input. Time for a jacket.");

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Conditions resolved. Back to neutral state.");

        // Code branches. Reality doesn’t.
    }
}
