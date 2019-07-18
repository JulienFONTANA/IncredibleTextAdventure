using System;

namespace IncredibleTextAdventure.ITAConsole
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLineFromConsole()
        {
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return "";
            }
            return line.Trim();
        }
    }
}
