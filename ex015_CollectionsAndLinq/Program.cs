// --- Lesson 15: Collections and LINQ ---
// Demonstrates List, Dictionary, and basic LINQ queries.
// Giannis Pythonopoulos collects data and bad decisions.

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: Basic List usage ---
        Console.WriteLine("List<int> demo: numbers Giannis pretends to understand.");

        List<int> numbers = new() { 5, 2, 9, 1, 5, 7 };

        Console.WriteLine("All numbers:");
        foreach (int n in numbers)
        {
            Console.Write($"{n} ");
        }

        Console.WriteLine();
        Console.WriteLine();

        // --- Section: LINQ filtering ---
        Console.WriteLine("Even numbers using LINQ:");
        var evenNumbers = numbers.Where(n => n % 2 == 0);

        foreach (int n in evenNumbers)
        {
            Console.Write($"{n} ");
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Numbers greater than 4, ordered ascending:");
        var filteredOrdered = numbers
            .Where(n => n > 4)
            .OrderBy(n => n);

        foreach (int n in filteredOrdered)
        {
            Console.Write($"{n} ");
        }

        Console.WriteLine();
        Console.WriteLine();

        // --- Section: List of custom objects ---
        Console.WriteLine("Developers list: Giannis and friends with questionable surnames.");

        List<Developer> devs = new()
        {
            new Developer("Giannis Pythonopoulos", "Python"),
            new Developer("Giannis Papapythonidis", "Python"),
            new Developer("Giannis Javascriptidis", "JavaScript"),
            new Developer("Giannis Csharpopoulos", "C#"),
            new Developer("Giannis Karacsharpoulou", "C#")
        };

        Console.WriteLine("All developers:");
        foreach (var dev in devs)
        {
            Console.WriteLine($" - {dev.FullName} [{dev.MainLanguage}]");
        }

        Console.WriteLine();
        Console.WriteLine("Filtering only C# developers using LINQ:");

        var csharpDevs = devs.Where(d => d.MainLanguage == "C#");

        foreach (var dev in csharpDevs)
        {
            Console.WriteLine($" - {dev.FullName}");
        }

        Console.WriteLine();

        // --- Section: Projection with Select ---
        Console.WriteLine("Projecting to anonymous labels (Select):");

        var labels = devs
            .Select(d => $"{d.FullName} writes {d.MainLanguage} when the coffee works.");

        foreach (var label in labels)
        {
            Console.WriteLine($" * {label}");
        }

        Console.WriteLine();

        // --- Section: Dictionary usage ---
        Console.WriteLine("Dictionary<string, int> demo: lines of code per language.");

        Dictionary<string, int> linesOfCode = new()
        {
            ["C#"] = 5000,
            ["Python"] = 3200,
            ["JavaScript"] = 2100
        };

        foreach (var kvp in linesOfCode)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} LOC");
        }

        Console.WriteLine();

        Console.WriteLine("Sorting dictionary by LOC descending:");
        var sortedByLoc = linesOfCode
            .OrderByDescending(pair => pair.Value);

        foreach (var kvp in sortedByLoc)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} LOC");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Collections disposed. LINQ queries still judging you.");

        // LINQ: making simple loops look outdated since 2007.
    }
}

// --- Section: Developer model used in LINQ examples ---
public class Developer
{
    public string FullName { get; }
    public string MainLanguage { get; }

    public Developer(string fullName, string mainLanguage)
    {
        FullName = fullName;
        MainLanguage = mainLanguage;
    }
}