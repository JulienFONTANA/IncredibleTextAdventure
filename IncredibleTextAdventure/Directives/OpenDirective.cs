using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.RoomStateManager;

namespace IncredibleTextAdventure.Directives
{
    // TODO - Still need this directive ???
    public class OpenDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IRoomStateManager _roomStateManager;

        private const string CmdPattern = "^(open)";
        private const string FullPattern = "^(open)[ \t]?(the)?(?<door>(.*))";

        public OpenDirective(IConsoleWriter consoleWriter,
            IRoomStateManager roomStateManager)
        {
            _consoleWriter = consoleWriter;
            _roomStateManager = roomStateManager;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, IGameContext context)
        {
            //var match = Regex.Match(cmd, FullPattern, RegexOptions.IgnoreCase);
            //if (match.Success)
            //{
            //    var capture = match.Groups["door"].Value.Trim();

            //    var door = context.GetCurrentRoom().GetItemsInRoom().FirstOrDefault(i => i.Name.EqualsIgnoreCase(capture) && i.IsItemVisible());
            //    if (ReferenceEquals(door, null))
            //    {
            //        _consoleWriter.WriteToConsole("What are you trying to open ?");
            //    }
            //    else
            //    {
            //        if (door.Name.EqualsIgnoreCase(Constants.Items.Door))
            //        {
            //            var key = context.GetPlayer().GetItemFromInventory(Constants.Items.Key);
            //            if (ReferenceEquals(key, null))
            //            {
            //                _consoleWriter.WriteToConsole($"You can't open the [{Constants.Items.Door}] without the [{Constants.Items.Key}] !");
            //                return;
            //            }

            //            OpenRoom(context, door, key);
            //        }
            //        else if (door.Name.EqualsIgnoreCase(Constants.Items.GoldenDoor))
            //        {
            //            var goldenKey = context.GetPlayer().GetItemFromInventory(Constants.Items.GoldenKey);
            //            if (ReferenceEquals(goldenKey, null))
            //            {
            //                _consoleWriter.WriteToConsole($"You can't open the [{Constants.Items.GoldenDoor}] without the [{Constants.Items.GoldenKey}] !");
            //                return;
            //            }

            //            OpenRoom(context, door, goldenKey);
            //        }
            //        else
            //        {
            //            _consoleWriter.WriteToConsole($"Can't open [{capture}]...");
            //        }
            //    }
            //}
        }

        private void OpenRoom(IGameContext context, IItem door, IItem key)
        {
            _consoleWriter.WriteToConsole(door.InteractWith(context));
            _roomStateManager.OpenRoom(context.GetRoom(door.BlocksPathTo()));
            context.GetPlayer().UseFromInventory(key);
        }
    }
}
