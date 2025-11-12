// --- Lesson 17: Async and Threads ---
// Demonstrates threading, async/await, and basic parallel execution.
// Giannis Pythonopoulos learns that multitasking is just organized chaos.

using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        // --- Section: Basic threading ---
        Console.WriteLine("Creating a new thread for Giannis Papapythonidis...");
        Thread thread = new Thread(WorkInParallel);
        thread.Start();

        Console.WriteLine("Main thread continues while Giannis works elsewhere...");
        Thread.Sleep(1000);
        Console.WriteLine("Main thread still alive. Amazing.");
        thread.Join();
        Console.WriteLine();

        // --- Section: Task-based async pattern ---
        Console.WriteLine("Now using Task.Run for non-blocking execution.");
        Task t1 = Task.Run(() => LongOperation("Giannis Javascriptidis", 1500));
        Task t2 = Task.Run(() => LongOperation("Giannis Csharpopoulos", 1000));
        Task t3 = Task.Run(() => LongOperation("Giannis Karacsharpoulos", 500));

        await Task.WhenAll(t1, t2, t3);
        Console.WriteLine();

        // --- Section: Async method with await ---
        Console.WriteLine("Running async method with await:");
        await GiannisAsyncProcess();

        Console.WriteLine();
        Console.WriteLine("All async tasks complete. Giannis Pythonopoulos feels productive.");
        Console.WriteLine();

        // --- Section: CancellationToken demo ---
        Console.WriteLine("Cancellation example:");
        using (CancellationTokenSource cts = new())
        {
            var token = cts.Token;
            var job = Task.Run(() => EndlessLoop(token));

            Console.WriteLine("Press any key to cancel Giannis’s infinite loop...");
            Console.ReadKey();
            cts.Cancel();

            try
            {
                await job;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Loop cancelled. Sanity preserved.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to clear...");
        Console.ReadKey();

        // --- Section: Clear screen ---
        Console.Clear();
        Console.WriteLine("Threads completed. Time resumes its illusion.");

        // Async code: faster, until it isn't.
    }

    // --- Section: Thread method ---
    static void WorkInParallel()
    {
        Console.WriteLine("Giannis Papapythonidis is working in a separate thread...");
        Thread.Sleep(800);
        Console.WriteLine("Giannis Papapythonidis finished his parallel thoughts.");
    }

    // --- Section: Task method ---
    static void LongOperation(string name, int delay)
    {
        Console.WriteLine($"{name} started work on thread {Thread.CurrentThread.ManagedThreadId}.");
        Thread.Sleep(delay);
        Console.WriteLine($"{name} finished work after {delay}ms.");
    }

    // --- Section: Async method ---
    static async Task GiannisAsyncProcess()
    {
        Console.WriteLine("Giannis Pythonopoulos starts an async operation.");
        await Task.Delay(1000);
        Console.WriteLine("Giannis Pythonopoulos awaits enlightenment...");
        await Task.Delay(1000);
        Console.WriteLine("Giannis Pythonopoulos finishes async task successfully, emotionally unchanged.");
    }

    // --- Section: Cancellation loop ---
    static void EndlessLoop(CancellationToken token)
    {
        int counter = 0;
        while (true)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"Loop iteration {++counter}");
            Thread.Sleep(300);
        }
    }
}
