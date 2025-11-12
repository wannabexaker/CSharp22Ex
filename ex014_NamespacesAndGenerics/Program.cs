// --- Lesson 14: Namespaces and Generics ---
// Demonstrates organizing code with namespaces, using generic classes,
// and extending existing types. Giannis Pythonopoulos tries not to repeat himself.

using System;
using System.Collections.Generic;

// --- Section: Namespace usage ---
namespace DevAcademy.Core
{
    public class GenericContainer<T>
    {
        private readonly List<T> items = new();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void DisplayAll()
        {
            Console.WriteLine($"Container holds {items.Count} item(s):");
            foreach (var i in items)
                Console.WriteLine($" - {i}");
        }
    }
}

// --- Section: Extension method namespace ---
namespace DevAcademy.Extensions
{
    public static class ListExtensions
    {
        public static void PrintAll<T>(this List<T> list)
        {
            Console.WriteLine($"List contains {list.Count} element(s):");
            foreach (var item in list)
                Console.WriteLine($" * {item}");
        }
    }
}

// --- Section: Program namespace ---
namespace DevAcademy.Demo
{
    using DevAcademy.Core;
    using DevAcademy.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            // --- Section: Generic class demonstration ---
            Console.WriteLine("Giannis Pythonopoulos experiments with generics.");
            GenericContainer<string> messages = new();
            messages.Add("Generics are templates for people who hate repetition.");
            messages.Add("They also make code unreadable faster.");
            messages.DisplayAll();

            Console.WriteLine();

            GenericContainer<int> numbers = new();
            numbers.Add(10);
            numbers.Add(42);
            numbers.Add(1337);
            numbers.DisplayAll();

            Console.WriteLine();

            // --- Section: Using extension method ---
            Console.WriteLine("Now Giannis extends functionality without touching the class.");
            List<string> surnames = new() { "Papapythonidis", "Csharpopoulos", "Javascriptidis", "Karacsharpoulou" };
            surnames.PrintAll();

            Console.WriteLine();

            // --- Section: Generic constraint example ---
            Console.WriteLine("Generic constraint demo:");
            Repository<Developer> repo = new();
            repo.Save(new Developer("Giannis Papapythonidis"));
            repo.Save(new Developer("Katerina Csharpoulou"));
            repo.PrintAll();

            Console.WriteLine();
            Console.WriteLine("Press any key to clear...");
            Console.ReadKey();

            // --- Section: Clear screen ---
            Console.Clear();
            Console.WriteLine("Generics compiled successfully. Understanding remains optional.");

            // Type safety is the illusion of control.
        }
    }

    // --- Section: Constraint demonstration ---
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> data = new();

        public void Save(T entity)
        {
            data.Add(entity);
            Console.WriteLine($"Saved: {entity.GetName()}");
        }

        public void PrintAll()
        {
            Console.WriteLine("Repository contents:");
            foreach (var e in data)
                Console.WriteLine($" - {e.GetName()}");
        }
    }

    public interface IEntity
    {
        string GetName();
    }

    public class Developer : IEntity
    {
        private readonly string fullName;

        public Developer(string name)
        {
            fullName = name;
        }

        public string GetName() => fullName;
    }
}
