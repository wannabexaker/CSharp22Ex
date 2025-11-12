// --- Utilities/Extensions.cs ---
// Helper extensions for formatting.

using System.Globalization;

namespace FinalBossEnterprize.Utilities
{
    public static class Extensions
    {
        public static string ToCurrency(this double value)
        {
            return value.ToString("C2", CultureInfo.InvariantCulture);
        }
    }
}
