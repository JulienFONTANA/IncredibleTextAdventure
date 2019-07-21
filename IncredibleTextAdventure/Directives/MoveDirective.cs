using System;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class MoveDirective : IDirective
    {
        private IConsoleWriter _consoleWriter;
        private const string CmdPattern = @"^(move|go)";
        private const string FullPattern = @"^(move|go)[ \t]?(?<capture>(.*))";

        public MoveDirective(IConsoleWriter consoleWriter)
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

                if (capture.Equals("N", StringComparison.OrdinalIgnoreCase)
                 || capture.Equals("North", StringComparison.OrdinalIgnoreCase))
                {
                    context.Player.yCoord += 1;
                }
                else if (capture.Equals("S", StringComparison.OrdinalIgnoreCase)
                      || capture.Equals("South", StringComparison.OrdinalIgnoreCase))
                {
                    context.Player.yCoord -= 1;
                }
                else if (capture.Equals("E", StringComparison.OrdinalIgnoreCase)
                      || capture.Equals("East", StringComparison.OrdinalIgnoreCase))
                {
                    context.Player.xCoord += 1;
                }
                else if (capture.Equals("W", StringComparison.OrdinalIgnoreCase)
                      || capture.Equals("West", StringComparison.OrdinalIgnoreCase))
                {
                    context.Player.xCoord -= 1;
                }
                else
                {
                    _consoleWriter.WriteToConsole("You can't go there.");
                }
            }
        }
    }
}
