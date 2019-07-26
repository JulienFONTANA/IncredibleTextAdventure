using System;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class PickDirective : IDirective
    {
        private IConsoleWriter _consoleWriter;
        private const string CmdPattern = @"^(pick|get|take|grab)";
        private const string FullPattern = @"^(pick|get|take|grab)[ \t]?(the|up)?[ \t]?(?<capture>(.*))";

        public PickDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, GameContext context)
        {
            var match = Regex.Match(cmd, FullPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var capture = match.Groups["capture"].Value.Trim();

                var objToPickUp = context.GetCurrentRoom().GetItemsInRoom().FirstOrDefault(i => i.Name.Equals(capture, StringComparison.OrdinalIgnoreCase));
                if (ReferenceEquals(objToPickUp, null))
                {
                    _consoleWriter.WriteToConsole("What are you trying to pick up?");
                    return;
                }

                if (!objToPickUp.CanBePickedUp)
                {
                    _consoleWriter.WriteToConsole($"There's no way you can pick up [{objToPickUp.Name}]...");
                    return;
                }

                context.GetPlayer().AddToInventory(objToPickUp);
                context.GetCurrentRoom().RemoveItemFromRoom(objToPickUp);
            }
        }
    }
}
