using System.Text.RegularExpressions;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives.Stairs
{
    public class LookOverridesDirective : LookDirective, IStairsDirective
    {
        public LookOverridesDirective(IConsoleWriter consoleWriter) : base(consoleWriter) { }

        public new void TryApply(string cmd, IGameContext context)
        {
            base.TryApply(cmd, context);

            if (Regex.IsMatch(cmd, "(bust)", RegexOptions.IgnoreCase))
            {
                context.GetCurrentRoom().GetItem(Constants.Items.Note).SetItemVisibility(true);
            }
        }
    }
}