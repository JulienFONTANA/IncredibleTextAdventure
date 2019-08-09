using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.RoomLinker;

namespace IncredibleTextAdventure.Service
{
    public class ItaService : IItaService
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IGameContext _gameContext;
        private readonly IRoomLinker _roomLinker;

        public ItaService(IConsoleReader consoleReader,
            IConsoleWriter consoleWriter,
            IGameContext gameContext,
            IRoomLinker roomLinker)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
            _gameContext = gameContext;
            _roomLinker = roomLinker;
        }

        public void Play()
        {
            var inGame = true;

            InitGame();
            while (inGame)
            {
                var cmd = _consoleReader.ReadLineFromConsole();
                if (string.IsNullOrEmpty(cmd))
                    continue;

                inGame = !_gameContext.Command(cmd);
            }

            _consoleReader.ReadLineFromConsole();
        }

        private void InitGame()
        {
            _roomLinker.InitRoomConnection();

            var startingRoom = _gameContext.GetRoom(_gameContext.GetPlayer().GetPlayerStartingLocation());
            _gameContext.GetPlayer().SetPlayerLocation(startingRoom);
            startingRoom.SetFirstTimeFalse();
            _consoleWriter.WriteToConsole(startingRoom.FirstDescription);
        }
    }
}
