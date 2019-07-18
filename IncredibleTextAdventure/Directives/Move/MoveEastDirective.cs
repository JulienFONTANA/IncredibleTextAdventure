using IncredibleTextAdventure.Characters;
using System;

namespace IncredibleTextAdventure.Directives.Move
{
    public class MoveEastDirective : IDirective
    {
        public void Execute(IPlayer player)
        {
            player.xCoord += 1;
        }

        public bool CanApply(string cmd)
        {
            return cmd.Equals("E", StringComparison.OrdinalIgnoreCase)
                || cmd.Equals("East", StringComparison.OrdinalIgnoreCase);
        }
    }
}
