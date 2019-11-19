﻿using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.LanguageModule;
using IncredibleTextAdventure.Service.RoomLinker;

namespace IncredibleTextAdventure.Service
{
    public class ItaService : IItaService
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IGameContext _gameContext;
        private readonly IRoomLinker _roomLinker;
        private readonly ILanguageConst _languageConst;

        public ItaService(IConsoleReader consoleReader,
            IConsoleWriter consoleWriter,
            IGameContext gameContext,
            IRoomLinker roomLinker,
            ILanguageConst languageConst)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
            _gameContext = gameContext;
            _roomLinker = roomLinker;
            _languageConst = languageConst;
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
            _consoleWriter.WriteToConsole(_languageConst.WelcomeMessage);
#if DEBUG
            _consoleWriter.WriteToConsole("!!! You are in [DEBUG MODE] - To experience the game as expected, you should play on [RELEASE MODE]. !!!");
#endif
            _consoleWriter.WriteToConsole(startingRoom.FirstDescription);
        }
    }
}
