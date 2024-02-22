using System;
using System.Windows.Forms;

namespace InvAddIn
{
    /// <summary>
    /// Provides a utility for handling exceptions, displaying messages, logging, and logging to the console.
    /// </summary>
    internal class ExceptionHandler
    {
        /// <summary>
        /// Handles an exception by displaying an error message, logging the exception, and printing the error message to the console.
        /// </summary>
        /// <param name="ex">The exception to be handled.</param>
        public static void HandleException(Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine($"Error: {ex.Message}");
            LogRecorder.LogException(ex);
        }
    }
}
