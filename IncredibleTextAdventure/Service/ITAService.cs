using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.ITAConsole;
using System;

namespace IncredibleTextAdventure.Service
{
    public class ITAService : IITAService
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IDirective[] _moveDirectives;
        private readonly IPlayer _player;

        public ITAService(IConsoleReader consoleReader,
            IConsoleWriter consoleWriter,
            IDirective[] moveDirectives,
            IPlayer player)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
            _moveDirectives = moveDirectives;
            _player = player;
        }

        public void Play()
        {
            bool inGame = true;

            _consoleWriter.WriteToConsole("Hello there...");
            while (inGame)
            {
                var line = _consoleReader.ReadLineFromConsole();

                foreach (var move in _moveDirectives)
                {
                    if (move.CanApply(line))
                    {
                        move.Execute(_player);
                        _player.Info();
                    }
                }

                if (line.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    inGame = false;
                }
            }
        }
    }
}
