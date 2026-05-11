using System;
using System.IO;

namespace appClassePessoaBD.Helpers
{
    public static class Logger
    {
        private static readonly string _logPath = Path.Combine(FileSystem.AppDataDirectory, "app_debug.log");

        public static void Log(string message)
        {
            try
            {
                // Criar diretório se não existir
                var logDirectory = Path.GetDirectoryName(_logPath);
                if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
                File.AppendAllText(_logPath, logMessage + Environment.NewLine);
                Console.WriteLine(logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO AO LOGAR: {ex.Message}");
            }
        }

        public static void LogError(string message, Exception ex)
        {
            Log($"ERRO: {message}");
            Log($"Exception: {ex.Message}");
            Log($"StackTrace: {ex.StackTrace}");
        }

        public static string GetLogPath()
        {
            return _logPath;
        }
    }
}
