using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using System.Linq;

namespace IncredibleTextAdventure.Service.Context
{
    public class GameContext : IGameContext
    {
        private readonly IPlayer _player;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConsoleReader _consoleReader;
        private readonly IDirective[] _directives;
        private readonly IRoom[] _rooms;

        public GameContext(IPlayer player,
            IConsoleWriter consoleWriter,
            IConsoleReader consoleReader,
            IDirective[] directives,
            IRoom[] rooms)
        {
            _player = player;
            _consoleWriter = consoleWriter;
            _consoleReader = consoleReader;
            _directives = directives;
            _rooms = rooms;
        }

        public bool Command(string cmd)
        {
            if (cmd.Equals("exit", System.StringComparison.OrdinalIgnoreCase))
            {
                return CheckExitGame();
            }

            var foundAction = false;
            foreach (var action in _directives)
            {
                if (action.CanApply(cmd))
                {
                    action.TryApply(cmd, this);
                    foundAction = true;
                }
            }
            var specialDirectives = GetCurrentRoom().GetSpecialDirectives();
            if (specialDirectives.Any())
            {
                foreach (var action in specialDirectives)
                {
                    if (action.CanApply(cmd))
                    {
                        action.TryApply(cmd, this);
                        foundAction = true;
                    }
                }
            }
            if (!foundAction)
            {
                _consoleWriter.WriteToConsole("You can't do that...");
            }
            return false;
        }

        public IRoom GetCurrentRoom()
        {
            return _rooms.FirstOrDefault(r => r.Equals(GetPlayer().GetPlayerLocalisation()));
        }

        public IRoom GetRoom(string room)
        {
            return _rooms.FirstOrDefault(r => r.Name.Equals(room, System.StringComparison.OrdinalIgnoreCase));
        }

        public IRoom GetRoom(IRoom room)
        {
            return _rooms.FirstOrDefault(r => r.Equals(room));
        }

        public IPlayer GetPlayer()
        {
            return _player;
        }

        private bool CheckExitGame()
        {
            _consoleWriter.WriteToConsole("Are you sure you want to exit the game ? Exit is not a valid in game command. "
                                        + "If you want to exit the game, press 'Y'");
            var answer = _consoleReader.ReadLineFromConsole();
            if (answer.Trim().Equals("Y", System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
