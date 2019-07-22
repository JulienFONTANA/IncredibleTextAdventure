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

        // TODO - move this
        private const string introTextToPutSomewhereElse = @"You wake up with simple clothes in a small room. The walls are grey and smooth. "
                            + "Your eyes slowly gets used to darkness, and the shape of a [door] starts to form in front of you. In a corner "
                            + "is a small [table], made of crude wood. A metal [key] was put here on display.";

        public void Play()
        {
            bool inGame = true;

            _consoleWriter.WriteToConsole(introTextToPutSomewhereElse);
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
