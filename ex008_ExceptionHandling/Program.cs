// --- Lesson 08: Exception Handling ---
// Demonstrates how to catch, throw, and handle errors without crying.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Basic try-catch ---
        Console.WriteLine("Division test. Because math is rarely kind.");
        try
        {
            Console.Write("Enter a number: ");
            int a = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter another number: ");
            int b = int.Parse(Console.ReadLine() ?? "0");

            int result = a / b;
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("You divided by zero. The universe frowns upon you.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Not a valid number. Nice try though.");
        }
        finally
        {
            Console.WriteLine("Finally block executed. Because closure matters.");
        }

        Console.WriteLine();

        // --- Section: Throwing exceptions manually ---
        Console.WriteLine("Now throwing a controlled error...");
        try
        {
            ValidateName(null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Caught an exception: {ex.Message}");
        }

        Console.WriteLine();

        // --- Section: Custom exception example ---
        try
        {
            CheckAccessLevel(0);
        }
        catch (AccessDeniedException ex)
        {
            Console.WriteLine($"Access denied: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Program recovered. Confidence restored.");

        // Nothing says ‘professional’ like handling your own mistakes.
    }

    // --- Section: Method throwing built-in exception ---
    static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");

        Console.WriteLine($"Hello {name}");
    }

    // --- Section: Method throwing custom exception ---
    static void CheckAccessLevel(int level)
    {
        if (level < 1)
            throw new AccessDeniedException("User level too low. Probably an intern.");

        Console.WriteLine("Access granted.");
    }
}

// --- Section: Custom exception class ---
public class AccessDeniedException : Exception
{
    public AccessDeniedException(string message) : base(message)
    {
    }
}
