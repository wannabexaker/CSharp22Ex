// --- Lesson 19: Razor Pages Intro ---
// Demonstrates the structure and syntax of Razor Pages in ASP.NET Core.
// Giannis Pythonopoulos writes HTML and C# in the same file — truly dangerous.

using System;

namespace RazorAcademy
{
    // --- Section: Razor Page Simulation ---
    // In a real ASP.NET Core project, this file would be a .cshtml page with a paired PageModel class.
    // Here we simulate the concept in console form to understand the architecture.
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Razor Pages simulation — Giannis Pythonopoulos edition.");
            Console.WriteLine();

            // --- Section: Page initialization ---
            RazorPage homePage = new RazorPage("Home", new HomePageModel());
            RazorPage aboutPage = new RazorPage("About", new AboutPageModel());

            homePage.Render();
            Console.WriteLine();
            aboutPage.Render();

            Console.WriteLine();
            Console.WriteLine("Press any key to clear...");
            Console.ReadKey();

            // --- Section: Clear screen ---
            Console.Clear();
            Console.WriteLine("Page rendered. View returned. User unimpressed.");

            // Razor Pages: half HTML, half C#, fully misunderstood.
        }
    }

    // --- Section: RazorPage class ---
    public class RazorPage
    {
        private readonly string name;
        private readonly PageModel model;

        public RazorPage(string name, PageModel model)
        {
            this.name = name;
            this.model = model;
        }

        public void Render()
        {
            Console.WriteLine($"--- Rendering {name} Page ---");
            Console.WriteLine($"Title: {model.Title}");
            Console.WriteLine($"Content: {model.GetContent()}");
        }
    }

    // --- Section: Base PageModel ---
    public abstract class PageModel
    {
        public abstract string Title { get; }
        public abstract string GetContent();
    }

    // --- Section: Derived Razor Pages ---
    public class HomePageModel : PageModel
    {
        public override string Title => "Welcome to Razor Academy";

        public override string GetContent()
        {
            string username = "Giannis Papapythonidis";
            return $"<h1>Hello, {username}</h1>\n<p>You are learning Razor syntax without the HTML stress.</p>";
        }
    }

    public class AboutPageModel : PageModel
    {
        public override string Title => "About Giannis";

        public override string GetContent()
        {
            return "<p>Giannis Javascriptidis was last seen refactoring inline HTML into oblivion.</p>";
        }
    }
}
