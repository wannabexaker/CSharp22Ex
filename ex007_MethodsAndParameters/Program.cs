// --- Lesson 07: Methods and Parameters ---
// Demonstrates declaring methods, using parameters, returning values,
// and simple control flow through methods and switch statements.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Intro ---
        Console.WriteLine("Welcome to the salary calculator.");
        Console.WriteLine("You’ll see the same logic, just better organized this time.");
        Console.WriteLine();

        // --- Section: Calling simple methods ---
        SayHello();
        Console.WriteLine();

        // --- Section: Parameters and return values ---
        double baseSalary = 1200;
        double bonus = 300;
        double totalSalary = CalculateSalary(baseSalary, bonus);
        Console.WriteLine($"Total salary: {totalSalary}");
        Console.WriteLine();

        // --- Section: Switch example ---
        Console.Write("Enter department code (1=HR, 2=IT, 3=Sales): ");
        int department = int.Parse(Console.ReadLine() ?? "0");
        ShowDepartment(department);
        Console.WriteLine();

        // --- Section: Overloaded methods ---
        Console.WriteLine("Overload example:");
        PrintMessage("Hello from the main method.");
        PrintMessage("Hello again.", 2);
        Console.WriteLine();

        // --- Section: Optional parameters ---
        Console.WriteLine("Optional parameter example:");
        DisplayInfo("Alice");
        DisplayInfo("Bob", 28);
        Console.WriteLine();

        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("All methods completed successfully, allegedly.");

        // Functions never forget, even when you do.
    }

    // --- Section: Method without parameters ---
    static void SayHello()
    {
        Console.WriteLine("Hello there. This is a method without arguments.");
    }

    // --- Section: Method with parameters and return value ---
    static double CalculateSalary(double basePay, double bonus)
    {
        double result = basePay + bonus;
        return result;
    }

    // --- Section: Switch statement in a method ---
    static void ShowDepartment(int code)
    {
        switch (code)
        {
            case 1:
                Console.WriteLine("Department: Human Resources");
                break;
            case 2:
                Console.WriteLine("Department: IT Support");
                break;
            case 3:
                Console.WriteLine("Department: Sales Division");
                break;
            default:
                Console.WriteLine("Unknown department. Possibly marketing.");
                break;
        }
    }

    // --- Section: Method overloading ---
    static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    static void PrintMessage(string message, int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            Console.WriteLine(message);
        }
    }

    // --- Section: Method with optional parameter ---
    static void DisplayInfo(string name, int age = 25)
    {
        Console.WriteLine($"{name} is {age} years old.");
    }
}
