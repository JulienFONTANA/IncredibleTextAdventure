using IncredibleTextAdventure.Characters;
using System;

namespace IncredibleTextAdventure.Directives.Move
{
    public class MoveNorthDirective : IDirective
    {
        public void Execute(IPlayer player)
        {
            player.yCoord += 1;
        }

        public bool CanApply(string cmd)
        {
            return cmd.Equals("N", StringComparison.OrdinalIgnoreCase)
                || cmd.Equals("North", StringComparison.OrdinalIgnoreCase);
        }
    }
}
