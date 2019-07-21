using System;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class LookDirective : IDirective
    {
        private IConsoleWriter _consoleWriter;
                private const string CmdPattern = @"^(look)";
        private const string FullPattern = @"^(look)[ \t]?(at|the)?[ \t]?(?<capture>(.*))";

        public LookDirective(IConsoleWriter consoleWriter)
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
                var capture = match.Groups["capture"].Value;
                var desc = context.AllItems.FirstOrDefault(i => i.Name.Equals(capture, StringComparison.OrdinalIgnoreCase))?.Description;
                if (ReferenceEquals(desc, null))
                {
                    _consoleWriter.WriteToConsole("What are you gazing at ? Nothingness ?");
                }
                _consoleWriter.WriteToConsole(desc);
            }
        }
    }
}
