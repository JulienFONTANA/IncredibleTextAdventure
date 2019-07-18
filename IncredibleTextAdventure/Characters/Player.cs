using IncredibleTextAdventure.ITAConsole;
using System;

namespace IncredibleTextAdventure.Characters
{
    public class Player : IPlayer
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }

        private readonly IConsoleWriter ConsoleWriter;

        public Player(IConsoleWriter consoleWriter)
        {
            xCoord = 0;
            yCoord = 0;

            ConsoleWriter = consoleWriter;
        }

        public void Info()
        {
            ConsoleWriter.WriteToConsole($"Player coordinates are {yCoord}°N - {xCoord}°E");
        }
    }
}
