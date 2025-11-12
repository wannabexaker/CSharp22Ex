// --- Lesson 10: Static, Const, and ReadOnly Members ---
// Demonstrates shared data, immutable fields, and why consts age poorly.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Static field and method ---
        Console.WriteLine("Static members belong to the class, not to you.");
        Counter.Increment();
        Counter.Increment();
        Console.WriteLine($"Counter value: {Counter.Value}");
        Console.WriteLine();

        // --- Section: Const vs ReadOnly ---
        Console.WriteLine("Constants and readonly fields in action.");
        ConstantsExample constants = new ConstantsExample(42);

        Console.WriteLine($"Const PI: {ConstantsExample.Pi}");
        Console.WriteLine($"Readonly field (set in constructor): {constants.SessionId}");
        Console.WriteLine();

        // --- Section: Static constructor demonstration ---
        Console.WriteLine($"Static initialization timestamp: {StaticInitializer.StartTime}");
        Console.WriteLine();

        // --- Section: Why static can be dangerous ---
        Console.WriteLine("Creating two instances of Logger...");
        Logger log1 = new Logger("First");
        Logger log2 = new Logger("Second");
        log1.Log("Message from log1");
        log2.Log("Message from log2");
        Console.WriteLine();

        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Static fields remain. Everything else is disposable.");

        // Global state: the fastest way to create global problems.
    }
}

// --- Section: Static field and method example ---
public static class Counter
{
    private static int count;

    static Counter()
    {
        count = 0;
    }

    public static void Increment() => count++;

    public static int Value => count;
}

// --- Section: Const and readonly example ---
public class ConstantsExample
{
    // const: must be known at compile time
    public const double Pi = 3.14159;

    // readonly: can be assigned in constructor
    public readonly int SessionId;

    public ConstantsExample(int sessionId)
    {
        SessionId = sessionId;
    }
}

// --- Section: Static constructor example ---
public static class StaticInitializer
{
    public static readonly DateTime StartTime;

    static StaticInitializer()
    {
        StartTime = DateTime.Now;
    }
}

// --- Section: Static side effects example ---
public class Logger
{
    private static int totalLogs = 0;
    private readonly string name;

    public Logger(string name)
    {
        this.name = name;
    }

    public void Log(string message)
    {
        totalLogs++;
        Console.WriteLine($"[{name}] ({totalLogs}) {message}");
    }
}
