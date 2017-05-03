using System;

namespace ComicBookLibraryManager.Helpers
{
    /// <summary>
    /// Provides a collection of helper methods for reading input from 
    /// and writing output to the console.
    /// </summary>
    static class ConsoleHelper
    {
        /// <summary>
        /// Reads user input from the console.
        /// </summary>
        /// <param name="prompt">The user prompt.</param>
        /// <param name="forceToLowercase">Whether or not to force the user's provided input to lowercase text.</param>
        /// <returns>A user's provided input as a string.</returns>
        public static string ReadInput(string prompt, bool forceToLowercase = false)
        {
            Console.WriteLine();
            Console.Write(prompt);
            string input = Console.ReadLine();
            return forceToLowercase ? input.ToLower() : input;
        }

        /// <summary>
        /// Clears the console output.
        /// </summary>
        public static void ClearOutput()
        {
            Console.Clear();
        }

        /// <summary>
        /// Writes the provided message to the console.
        /// </summary>
        /// <param name="message">The message to write to the console.</param>
        public static void Output(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Writes the provided format string and args to the console.
        /// </summary>
        /// <param name="format">The format string to write to the console.</param>
        /// <param name="arg">The arguments to use with the format string.</param>
        public static void Output(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        /// <summary>
        /// Writes the provided message to the console as a line.
        /// </summary>
        /// <param name="message">The message to write to the console.</param>
        /// <param name="outputBlankLineBeforeMessage">Whether or not to write a blank line before the message.</param>
        public static void OutputLine(string message, bool outputBlankLineBeforeMessage = true)
        {
            if (outputBlankLineBeforeMessage)
            {
                Console.WriteLine();
            }
            Console.WriteLine(message);
        }

        /// <summary>
        /// Writes the provided format string and args to the console as a line.
        /// </summary>
        /// <param name="format">The format string to write to the console.</param>
        /// <param name="arg">The arguments to use with the format string.</param>
        public static void OutputLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        /// <summary>
        /// Writes a blank line to the console.
        /// </summary>
        public static void OutputBlankLine()
        {
            Console.WriteLine();
        }
    }
}
