using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.RoomStateManager;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Directives.Corridor
{
    public class UseLanternDirective : ICorridorDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = "^(use lantern)";

        public UseLanternDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, GameContext context)
        {
            var lantern = context.GetPlayer().GetItemFromInventory(Constants.Items.Lantern);

            if (ReferenceEquals(lantern, null))
            {
                _consoleWriter.WriteToConsole("What are trying to do?");
                return;
            }

            _consoleWriter.WriteToConsole("As you lit up the [lantern], you are suddenly blinded by a flash. " +
                "After a few seconds, as your sight comes back, you find out that you dropped the [lantern], " +
                "but that strange [signs] now illuminates the corridor. And a new path to the [basement] has " +
                "been revealed ! ");

            context.GetCurrentRoom().GetItem(Constants.Items.Signs).SetItemVisibility(true);
            context.OpenRoom(context.GetRoom(Constants.Rooms.Basement));
            context.GetPlayer().UseFromInventory(context.GetPlayer().GetItemFromInventory(Constants.Items.Lantern));
        }
    }
}
