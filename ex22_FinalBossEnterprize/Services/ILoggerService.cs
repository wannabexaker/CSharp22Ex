// --- Services/ILoggerService.cs ---
// Logging abstraction for the application.

using System.Threading.Tasks;

namespace FinalBossEnterprize.Services
{
    public interface ILoggerService
    {
        void Log(string message);
        Task LogAsync(string message);
    }
}
