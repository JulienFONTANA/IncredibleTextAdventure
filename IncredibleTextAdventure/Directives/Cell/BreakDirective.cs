using System;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives.Cell
{
    public class BreakDirective : ICellDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = @"^(break)";
        private const string FullPattern = @"^(break)[ \t]?(the)?(?<capture>(.*))";

        public BreakDirective(IConsoleWriter consoleWriter)
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
                var item = context.GetCurrentRoom().GetItemsInRoom().FirstOrDefault(i => i.Name.Equals(capture, StringComparison.OrdinalIgnoreCase));

                if (ReferenceEquals(item, null))
                {
                    _consoleWriter.WriteToConsole("What are you trying to break ?");
                    return;
                }

                if (item.Name.Equals("Door", StringComparison.OrdinalIgnoreCase))
                {
                    _consoleWriter.WriteToConsole("You try for a while, but in the end the door didn't even move. Could there be a [key] somewhere ?");
                }
                if (item.Name.Equals("Table", StringComparison.OrdinalIgnoreCase))
                {
                    _consoleWriter.WriteToConsole("Without too much effort, you send the table flying across the cell. " 
                                                  + "Needless to say, it [shatters into pieces].");

                    item.SetItemVisibility(false);
                    context.GetCurrentRoom().GetItem("TableLeg").SetItemVisibility(true);
                    context.GetCurrentRoom().GetItem("BrokenTable").SetItemVisibility(true);
                }
            }
        }
    }
}
