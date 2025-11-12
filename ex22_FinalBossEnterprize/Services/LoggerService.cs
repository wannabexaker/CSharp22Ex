// --- Services/LoggerService.cs ---
// Simple logger writing entries to a text file and optionally to console.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FinalBossEnterprize.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly string _logPath;

        public LoggerService()
        {
            _logPath = "finalboss_log.txt";
        }

        public void Log(string message)
        {
            string entry = FormatEntry(message);
            File.AppendAllText(_logPath, entry, Encoding.UTF8);
        }

        public async Task LogAsync(string message)
        {
            string entry = FormatEntry(message);
            await File.AppendAllTextAsync(_logPath, entry, Encoding.UTF8);
        }

        private static string FormatEntry(string message)
        {
            return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
        }
    }
}
