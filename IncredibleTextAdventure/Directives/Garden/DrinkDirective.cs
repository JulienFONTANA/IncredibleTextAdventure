using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using System.Text.RegularExpressions;

namespace IncredibleTextAdventure.Directives.Garden
{
    public class DrinkDirective : IGardenDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = "^(drink)";

        public DrinkDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, GameContext context)
        {
            _consoleWriter.WriteToConsole("You put your hands together to drink from the [fountain]. The cold " +
                                          "water cleans your spirit and you feel calm, rested.");
        }
    }
}
