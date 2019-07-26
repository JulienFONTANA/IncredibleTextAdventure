using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using System.Linq;

namespace IncredibleTextAdventure.Service.Context
{
    public class GameContext : IGameContext
    {
        public IPlayer Player { get; set; }

        private readonly IConsoleWriter _console;
        private readonly IDirective[] _directives;
        private readonly IRoom[] _rooms;

        public GameContext(IPlayer player,
            IConsoleWriter console,
            IDirective[] directives,
            IRoom[] rooms)
        {
            Player = player;
            _console = console;
            _directives = directives;
            _rooms = rooms;
        }

        public void Command(string cmd)
        {
            bool foundAction = false;

            foreach (var action in _directives)
            {
                if (action.CanApply(cmd))
                {
                    action.TryApply(cmd, this);
                    foundAction = true;
                }
            }
            if (!foundAction)
            {
                _console.WriteToConsole("You can't do that...");
            }
        }

        public IRoom GetCurrentRoom()
        {
            return _rooms.FirstOrDefault(r => r.Name.Equals(Player.GetPlayerLocalisation(), System.StringComparison.OrdinalIgnoreCase));
        }

        public IRoom GetRoom(string room)
        {
            return _rooms.FirstOrDefault(r => r.Name.Equals(room, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
