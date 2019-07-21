using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Items;
using System.Collections.Generic;

namespace IncredibleTextAdventure.Service.Context
{
    public class GameContext : IGameContext
    {
        // TODO - Right now, Context contains all items. I'll have to introduce "rooms" or something
        public List<IItem> AllItems { get; set; }

        public IPlayer Player { get; set; }

        private readonly IDirective[] _directives;

        public GameContext(IPlayer player,
            IDirective[] directives)
        {
            Player = player;
            AllItems = new List<IItem>
            {
                new Key(),
                new Door(),
                new Table()
            };
            _directives = directives;
        }

        public void Command(string cmd)
        {
            foreach (var action in _directives)
            {
                if (action.CanApply(cmd))
                {
                    action.TryApply(cmd, this);
                    Player.Info();
                }
            }
        }
    }
}
