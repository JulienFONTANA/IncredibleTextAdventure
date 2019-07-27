using System;

namespace IncredibleTextAdventure.ITAConsole
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLineFromConsole()
        {
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return string.Empty;
            }
            return line.Trim();
        }
    }
}
