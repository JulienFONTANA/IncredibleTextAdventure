using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Items;
using System.Collections.Generic;

namespace IncredibleTextAdventure.Service.Context
{
    public class GameContext : IGameContext
    {
        // TODO - Right now, Context contains all items. I'll have to introduce "rooms" or something
        private readonly List<IItem> _allItems;
        private readonly IDirective[] _directives;
        private readonly IPlayer _player;

        public GameContext(IPlayer player,
            IDirective[] directives)
        {
            _player = player;
            _allItems = new List<IItem>
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
                    action.Execute(_player);
                    _player.Info();
                }
            }
        }
    }
}
