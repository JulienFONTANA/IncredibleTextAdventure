using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using System;

namespace IncredibleTextAdventure.Service
{
    public class ITAService : IITAService
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IGameContext _gameContext;

        public ITAService(IConsoleReader consoleReader,
            IConsoleWriter consoleWriter,
            IGameContext gameContext)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
            _gameContext = gameContext;
        }

        public void Play()
        {
            bool inGame = true;

            _consoleWriter.WriteToConsole("You wake up with simple clothes in a small room. A lock [door] is in front of you. In a corner is a [table], with a [key] on it.");
            while (inGame)
            {
                var cmd = _consoleReader.ReadLineFromConsole();

                _gameContext.Command(cmd);

                if (cmd.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    inGame = false;
                }
            }
        }
    }
}
