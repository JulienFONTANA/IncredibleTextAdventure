using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives.Garden
{
    public class DrinkDirective : IGardenDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = @"^(Drink)[ \t]?(from fountain)?";

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
            _consoleWriter.WriteToConsole($"You try to drink from the fountain, but alas, it's empty !");
        }
    }
}
