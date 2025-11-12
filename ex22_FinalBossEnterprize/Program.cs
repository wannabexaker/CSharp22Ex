// --- FinalBossEnterprize: Core Entry Point ---
// Sets up dependency injection and starts the StoreController menu.

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FinalBossEnterprize.Controllers;
using FinalBossEnterprize.Data;
using FinalBossEnterprize.Services;

namespace FinalBossEnterprize
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            // Data layer
            services.AddSingleton<IDataRepository, DataRepository>();

            // Services
            services.AddSingleton<ILoggerService, LoggerService>();

            // Controllers
            services.AddTransient<StoreController>();

            var provider = services.BuildServiceProvider();

            var controller = provider.GetRequiredService<StoreController>();

            await controller.RunMenuAsync();

            Console.WriteLine();
            Console.WriteLine("Application terminated. Logs should explain the damage.");
        }
    }
}
