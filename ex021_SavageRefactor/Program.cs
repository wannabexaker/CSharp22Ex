// --- Lesson 21: Savage Refactor ---
// Professional structure template for the Final Boss refactor.
// Configure DI here only. Keep it minimal and clean.

using Microsoft.Extensions.DependencyInjection;
using ex021_SavageRefactor.Controllers;
using ex021_SavageRefactor.Data;
using ex021_SavageRefactor.Services;

namespace ex021_SavageRefactor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // === Dependency Injection Setup ===
            // TODO:
            // 1. Create a new ServiceCollection().
            // 2. Register your interfaces and implementations.
            // 3. Build ServiceProvider.
            // 4. Resolve StoreController and call RunMenuAsync().

            // Example (pseudo):
            // var services = new ServiceCollection();
            // services.AddSingleton<IDataRepository, DataRepository>();
            // services.AddSingleton<ILoggerService, LoggerService>();
            // services.AddTransient<StoreController>();
            // var provider = services.BuildServiceProvider();
            //
            // var controller = provider.GetRequiredService<StoreController>();
            // await controller.RunMenuAsync();
        }
    }
}
