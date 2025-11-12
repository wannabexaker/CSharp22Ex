// --- Controllers/StoreController.cs ---
// Handles user interaction flow using data and services.
// This is the "C" in MVC: it coordinates, it doesn't store data or render HTML.

using System;
using System.Linq;
using System.Threading.Tasks;
using FinalBossEnterprize.Data;
using FinalBossEnterprize.Models;
using FinalBossEnterprize.Services;
using FinalBossEnterprize.Views;
using FinalBossEnterprize.Utilities;

namespace FinalBossEnterprize.Controllers
{
    public class StoreController
    {
        private readonly IDataRepository _repository;
        private readonly ILoggerService _logger;

        public StoreController(IDataRepository repository, ILoggerService logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task RunMenuAsync()
        {
            bool running = true;

            await _logger.LogAsync("StoreController started.");

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("=== FinalBossEnterprize Store ===");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Create Order");
                Console.WriteLine("3. View Orders");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        await DisplayProductsAsync();
                        break;
                    case "2":
                        await CreateOrderAsync();
                        break;
                    case "3":
                        await ShowOrdersAsync();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        RazorView.RenderMessage("Invalid choice. Controller rolling its eyes silently.");
                        break;
                }
            }

            await _logger.LogAsync("StoreController stopped.");
        }

        public async Task DisplayProductsAsync()
        {
            var products = await _repository.GetProductsAsync();
            RazorView.RenderProductList(products);
        }

        public async Task CreateOrderAsync()
        {
            var products = await _repository.GetProductsAsync();
            RazorView.RenderProductList(products);

            Console.Write("Enter product IDs (comma-separated): ");
            string? idsInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idsInput))
            {
                RazorView.RenderMessage("No IDs entered. Order ignored.");
                return;
            }

            var ids = idsInput
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s.Trim(), out var id) ? id : -1)
                .Where(id => id > 0)
                .ToArray();

            if (ids.Length == 0)
            {
                RazorView.RenderMessage("No valid IDs detected. Impressive.");
                return;
            }

            var order = await _repository.CreateOrderAsync(ids);
            await _logger.LogAsync($"Order #{order.Id} created with {order.Items.Count} item(s).");

            RazorView.RenderOrderDetails(order);
        }

        public async Task ShowOrdersAsync()
        {
            var orders = await _repository.GetOrdersAsync();
            RazorView.RenderOrderList(orders);
        }
    }
}
