using System;
using System.IO;

namespace InvAddIn
{
    internal class LogRecorder
    {
        
        private const string LogFilePath = @"D:\Mayur_Workspace\Incubation\BoltAddin\log.txt";
        /// <summary>
        /// Logs an exception, including timestamp, error message, and stack trace.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        public static void LogException(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine($"Timestamp: {DateTime.Now}");
                    writer.WriteLine($"Error Message: {ex.Message}");
                    writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                    writer.WriteLine(new string('-', 50)); // Separator for better readability
                }
            }
            catch (Exception logEx)
            {
                // Log any exception that occurs during logging to console
                Console.WriteLine($"Error during logging: {logEx.Message}");
            }
        }
    }
}
