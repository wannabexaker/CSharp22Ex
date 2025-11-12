// --- Lesson 16: StringBuilder and File I/O ---
// Demonstrates efficient string manipulation and file operations.
// Giannis Pythonopoulos now writes to disk because memory is temporary.

using System;
using System.IO;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Section: String concatenation problem ---
        Console.WriteLine("Comparing naive concatenation vs StringBuilder performance.");

        string naive = "";
        for (int i = 0; i < 5; i++)
        {
            naive += $"Line {i} - Written by Giannis Papapythonidis\n";
        }

        Console.WriteLine("Naive string result:");
        Console.WriteLine(naive);

        Console.WriteLine();

        // --- Section: StringBuilder solution ---
        StringBuilder sb = new();
        for (int i = 0; i < 5; i++)
        {
            sb.AppendLine($"Line {i} - Optimized by Giannis Csharpopoulos");
        }

        string builtString = sb.ToString();
        Console.WriteLine("StringBuilder result:");
        Console.WriteLine(builtString);

        Console.WriteLine();

        // --- Section: Writing to file ---
        string filePath = "giannis_notes.txt";
        Console.WriteLine($"Writing data to file: {filePath}");
        File.WriteAllText(filePath, builtString);

        Console.WriteLine("File created successfully. Probably where you didn’t expect it.");
        Console.WriteLine();

        // --- Section: Reading from file ---
        Console.WriteLine("Reading file contents:");
        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine(fileContent);

        Console.WriteLine();

        // --- Section: Appending to file ---
        Console.WriteLine("Appending new line...");
        File.AppendAllText(filePath, "Final remark from Giannis Javascriptidis: everything is temporary.\n");

        Console.WriteLine("Re-reading updated file:");
        string updated = File.ReadAllText(filePath);
        Console.WriteLine(updated);

        Console.WriteLine();

        // --- Section: StreamWriter and StreamReader ---
        Console.WriteLine("Using StreamWriter and StreamReader for a more manual experience.");
        string streamFile = "giannis_stream.txt";

        using (StreamWriter writer = new StreamWriter(streamFile))
        {
            writer.WriteLine("Ioanna Karacsharpoulou is writing with StreamWriter.");
            writer.WriteLine("She enjoys full control and no safety nets.");
        }

        using (StreamReader reader = new StreamReader(streamFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Files saved. Strings built. RAM relieved.");

        // Files remember what developers forget.
    }
}
