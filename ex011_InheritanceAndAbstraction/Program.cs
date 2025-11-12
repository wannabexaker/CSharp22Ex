// --- Lesson 12: Interfaces and Implementation ---
// Demonstrates defining and implementing interfaces.
// In short: contracts that classes pretend to respect.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Basic interface usage ---
        Console.WriteLine("Interface demonstration with Giannis at the keyboard.");
        IWorker giannis = new Developer("Giannis");
        giannis.Work();
        giannis.Report();

        Console.WriteLine();

        // --- Section: Multiple interfaces ---
        Console.WriteLine("Now Giannis multitasks. Because one interface isn’t enough.");
        IMentor mentorGiannis = new Developer("Giannis");
        mentorGiannis.Guide();

        Console.WriteLine();

        // --- Section: Explicit implementation ---
        Console.WriteLine("Explicit implementation demo:");
        IReviewer reviewerGiannis = new Developer("Giannis");
        reviewerGiannis.Review("Pull Request #404");
        Console.WriteLine();

        // --- Section: Type checking with 'is' and 'as' ---
        Console.WriteLine("Type checking in slow motion:");
        object obj = giannis;
        if (obj is IWorker worker)
        {
            Console.WriteLine("Confirmed: object implements IWorker.");
            worker.Work();
        }

        Developer? dev = obj as Developer;
        if (dev != null)
        {
            Console.WriteLine("Cast successful. Developer detected.");
        }

        Console.WriteLine();

        // --- Section: Practical example ---
        Console.WriteLine("Giannis is now managing a Library Interface demo.");
        ILibrary library = new SimpleLibrary();
        library.AddBook("C# for Realists");
        library.AddBook("Async and the Art of Waiting");
        library.ListBooks();

        Console.WriteLine();

        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Interfaces detached. Reality restored.");

        // Interfaces: the art of making promises without commitment.
    }
}

// --- Section: Basic interfaces ---
public interface IWorker
{
    void Work();
    void Report();
}

public interface IMentor
{
    void Guide();
}

public interface IReviewer
{
    void Review(string item);
}

// --- Section: Implementing multiple interfaces ---
public class Developer : IWorker, IMentor, IReviewer
{
    private string name;

    public Developer(string name)
    {
        this.name = name;
    }

    public void Work()
    {
        Console.WriteLine($"{name} is writing code and pretending to understand requirements.");
    }

    public void Report()
    {
        Console.WriteLine($"{name} sent a status report. Nobody read it.");
    }

    public void Guide()
    {
        Console.WriteLine($"{name} is mentoring Totos. Both are confused but optimistic.");
    }

    // Explicit interface implementation
    void IReviewer.Review(string item)
    {
        Console.WriteLine($"{name} reviewed {item}. It’s fine. Probably.");
    }
}

// --- Section: Library interface example ---
public interface ILibrary
{
    void AddBook(string title);
    void ListBooks();
}

public class SimpleLibrary : ILibrary
{
    private readonly List<string> books = new();

    public void AddBook(string title)
    {
        books.Add(title);
        Console.WriteLine($"Added book: {title}");
    }

    public void ListBooks()
    {
        Console.WriteLine("Library contents:");
        foreach (var book in books)
        {
            Console.WriteLine($" - {book}");
        }
    }
}
