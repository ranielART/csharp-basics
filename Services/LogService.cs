using System;
using System.IO;
using System.Threading.Tasks;

namespace csharp_basics.Services
{
    internal class LogService
    {
        private readonly string filePath = "log.txt";

        public async Task LogAsync(string type, string message)
        {
            string log = $"[{type}] {message} | {DateTime.Now:yyyy-MM-dd hh:mm:ss tt}\n";

            try
            {
                await File.AppendAllTextAsync(filePath, log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOG ERROR] {ex.Message}");
            }
        }
    }
}
