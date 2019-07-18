using IncredibleTextAdventure.Characters;
using System;

namespace IncredibleTextAdventure.Directives.Move
{
    public class MoveWestDirective : IDirective
    {
        public void Execute(IPlayer player)
        {
            player.xCoord -= 1;
        }

        public bool CanApply(string cmd)
        {
            return cmd.Equals("W", StringComparison.OrdinalIgnoreCase)
                || cmd.Equals("West", StringComparison.OrdinalIgnoreCase);
        }
    }
}
