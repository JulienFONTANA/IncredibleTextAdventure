using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class HelpDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = "^(help)";

        public HelpDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, GameContext context)
        {
            _consoleWriter.WriteToConsole("TODO : Write help !");
        }
    }
}
