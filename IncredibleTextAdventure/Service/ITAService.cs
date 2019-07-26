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

            InitGame();
            while (inGame)
            {
                var cmd = _consoleReader.ReadLineFromConsole();
                if (!string.IsNullOrEmpty(cmd))
                {
                    _gameContext.Command(cmd);

                    if (cmd.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        inGame = false;
                    }
                }
            }
        }

        private void InitGame()
        {
            var room = _gameContext.GetRoom(_gameContext.Player.GetPlayerLocalisation());
            room.IsFirstTime = false;
            _consoleWriter.WriteToConsole(room.FirstDescription);
        }
    }
}
