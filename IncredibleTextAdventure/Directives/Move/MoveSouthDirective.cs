using IncredibleTextAdventure.Characters;
using System;

namespace IncredibleTextAdventure.Directives.Move
{
    public class MoveSouthDirective : IDirective
    {
        public void Execute(IPlayer player)
        {
            player.yCoord -= 1;
        }

        public bool CanApply(string cmd)
        {
            return cmd.Equals("S", StringComparison.OrdinalIgnoreCase)
                || cmd.Equals("South", StringComparison.OrdinalIgnoreCase);
        }
    }
}
