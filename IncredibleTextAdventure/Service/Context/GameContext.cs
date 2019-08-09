using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using System.Linq;
using IncredibleTextAdventure.Service.RoomStateManager;
using IncredibleTextAdventure.Service.SpecialEventManager;

namespace IncredibleTextAdventure.Service.Context
{
    public class GameContext : IGameContext
    {
        private readonly IPlayer _player;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConsoleReader _consoleReader;
        private readonly IDirective[] _directives;
        private readonly IRoom[] _rooms;
        private readonly ISpecialEventManager _specialEventManager;
        private readonly IRoomStateManager _roomStateManager;

        public GameContext(IPlayer player,
            IConsoleWriter consoleWriter,
            IConsoleReader consoleReader,
            IDirective[] directives,
            IRoom[] rooms,
            ISpecialEventManager specialEventManager,
            IRoomStateManager roomStateManager)
        {
            _player = player;
            _consoleWriter = consoleWriter;
            _consoleReader = consoleReader;
            _directives = directives;
            _rooms = rooms;
            _specialEventManager = specialEventManager;
            _roomStateManager = roomStateManager;
        }

        public bool Command(string cmd)
        {
            if (cmd.EqualsIgnoreCase("Exit") || cmd.EqualsIgnoreCase("Quit"))
            {
                return CheckExitGame();
            }

            var foundAction = false;
            var specialDirectives = GetCurrentRoom().GetSpecialDirectives();
            if (specialDirectives.Any())
            {
                foreach (var action in specialDirectives)
                {
                    if (action.CanApply(cmd))
                    {
                        action.TryApply(cmd, this);
                        foundAction = true;
                        break;
                    }
                }
            }
            if (!foundAction)
            {
                foreach (var action in _directives)
                {
                    if (action.CanApply(cmd))
                    {
                        action.TryApply(cmd, this);
                        foundAction = true;
                        break;
                    }
                }
            }
            if (!foundAction)
            {
                _consoleWriter.WriteToConsole("You can't do that... ");
            }
            return false;
        }

        public IRoom GetCurrentRoom()
        {
            return _rooms.FirstOrDefault(r => r.Equals(GetPlayer().GetPlayerLocation()));
        }

        public IRoom GetRoom(string room)
        {
            return _rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(room));
        }

        public IRoom GetRoom(IRoom room)
        {
            return _rooms.FirstOrDefault(r => r.Equals(room));
        }

        public IPlayer GetPlayer()
        {
            return _player;
        }

        public void TriggerSpecialEvent(string eventName)
        {
            _specialEventManager.SpecialEvent(eventName, _player);
        }

        public void OpenRoom(IRoom room)
        {
            _roomStateManager.OpenRoom(room);
        }

        private bool CheckExitGame()
        {
            _consoleWriter.WriteToConsole("Are you sure you want to exit the game ? [Exit / Quit] is not a valid in game command. "
                                        + "If you want to exit the game, press 'Y'");
            var answer = _consoleReader.ReadLineFromConsole();
            if (answer.Trim().EqualsIgnoreCase("Y"))
            {
                return true;
            }
            return false;
        }
    }
}
