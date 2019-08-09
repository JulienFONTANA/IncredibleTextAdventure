using System.Text.RegularExpressions;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives.Bar
{
    public class EmptyBottleDirective : IBarDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = "^(empty bottle)";

        public EmptyBottleDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, GameContext context)
        {
            if (context.GetCurrentRoom().IsItemInRoom(Constants.Items.Bottle))
            {
                _consoleWriter.WriteToConsole("You empty the [bottle] in a sink. The dense and opaque liquid falls slowly out of the bottle. " +
                                              "The air doesn't smell that bad. After a few seconds, the liquid start to flow even faster. " +
                                              "It comes out as a single 'block' of dense matter, and disappear into the sink. You put the " +
                                              "[empty bottle] on the bar, and take a few seconds to realize that a [golden key] fell from " +
                                              "inside the bottle. ");
                context.TriggerSpecialEvent(Constants.Events.EmptyBottle);
            }
            else
            {
                _consoleWriter.WriteToConsole("You already emptied the bottle !");
            }
        }
    }
}
