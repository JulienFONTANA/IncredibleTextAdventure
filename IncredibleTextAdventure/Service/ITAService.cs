using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

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
                if (string.IsNullOrEmpty(cmd))
                    continue;

                inGame = !_gameContext.Command(cmd);
            }
        }

        private void InitGame()
        {
            var room = _gameContext.GetRoom(_gameContext.GetPlayer().GetPlayerLocalisation());
            room.SetFirstTimeFalse();
            _consoleWriter.WriteToConsole(room.FirstDescription);
        }
    }
}
