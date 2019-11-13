using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items.OtherItems;

namespace IncredibleTextAdventure.Directives.Garden
{
    public class FillBottleDirective : IGardenDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = "^(fill)";

        public FillBottleDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, IGameContext context)
        {
            var lantern = context.GetPlayer().GetItemFromInventory(Constants.Items.EmptyBottle);

            if (ReferenceEquals(lantern, null))
            {
                _consoleWriter.WriteToConsole("What are trying to do?");
                return;
            }

            _consoleWriter.WriteToConsole("You fill the [empty bottle] with water. Now, you have a weird [vase]. ");

            context.GetPlayer().UseFromInventory(context.GetPlayer().GetItemFromInventory(Constants.Items.EmptyBottle));
            context.GetPlayer().AddToInventory(new Vase(), false);
        }
    }
}
