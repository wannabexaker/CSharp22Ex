// --- Lesson 13: Enums and Switch ---
// Demonstrates enum declaration and switch control flow.
// Also features Giannis Pythonopoulos, a man of many suffixes.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Enum basics ---
        Console.WriteLine("Giannis Pythonopoulos chooses his programming mood:");
        Console.WriteLine("1 = Focused, 2 = Lazy, 3 = Debugging, 4 = Existential");
        Console.Write("Enter a number: ");

        int input = int.Parse(Console.ReadLine() ?? "0");
        DevState currentState = (DevState)input;

        Console.WriteLine();

        // --- Section: Switch using enum ---
        switch (currentState)
        {
            case DevState.Focused:
                Console.WriteLine("Giannis Papapythonidis writes 300 lines without breathing.");
                break;
            case DevState.Lazy:
                Console.WriteLine("Giannis Javascriptidis stares at the screen and calls it 'planning'.");
                break;
            case DevState.Debugging:
                Console.WriteLine("Giannis Csharpopoulos creates the bug report that will outlive him.");
                break;
            case DevState.Existential:
                Console.WriteLine("Giannis Karacsharpoulou wonders why the code even exists.");
                break;
            default:
                Console.WriteLine("Invalid state. Probably a syntax error in human form.");
                break;
        }

        Console.WriteLine();

        // --- Section: Enum in method call ---
        Console.WriteLine("Now evaluating performance bonus based on developer mood...");
        double bonus = CalculateBonus(currentState);
        Console.WriteLine($"Bonus: {bonus:C2}");

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Mood reset to default: Apathetic.");

        // Enums: because magic numbers deserve names too.
    }

    // --- Section: Method using enum parameter ---
    static double CalculateBonus(DevState state)
    {
        return state switch
        {
            DevState.Focused => 500.0,
            DevState.Lazy => 50.0,
            DevState.Debugging => 200.0,
            DevState.Existential => 0.0,
            _ => 0.0
        };
    }
}

// --- Section: Enum definition ---
public enum DevState
{
    Focused = 1,
    Lazy = 2,
    Debugging = 3,
    Existential = 4
}
