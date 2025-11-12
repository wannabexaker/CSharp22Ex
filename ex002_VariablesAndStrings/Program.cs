// --- Lesson 02: Variables and Strings ---
// Demonstrates declaring, assigning, reassigning, and combining string variables.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Declare and assign ---
        string studentName = "Scott";
        int age = 20;

        Console.WriteLine($"Hey {studentName}, I know you are {age} years old.");
        Console.WriteLine();

        // --- Section: Multiple string variables ---
        string message1 = "I'm your system trainer";
        string message2 = "We debug, therefore we are";

        Console.WriteLine(message1 + ", ");
        Console.WriteLine(message2);
        Console.WriteLine();

        // --- Section: Variable reassignment ---
        string note1 = "Initialization complete.";
        string note2 = "Proceed with caution.";

        Console.WriteLine(note1);
        Console.WriteLine(note2);

        note1 = "Recompiling thoughts...";
        Console.WriteLine(note1);
        Console.WriteLine();

        // --- Section: Multiple assignment ---
        string syncStatus;
        syncStatus = note1 = "I follow. If you get lost, we both get lost.";

        Console.WriteLine(syncStatus);
        Console.WriteLine(note1);
        Console.WriteLine();

        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("All variables gone. Console feels lighter now.");

        // Consistency is temporary. Refactoring is forever.
    }
}
