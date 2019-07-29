﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class LookDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = @"^(look)";
        private const string FullPattern = @"^(look)[ \t]?(at)?[ \t]?(the)?(?<capture>(.*))";

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
                var capture = match.Groups["capture"].Value.Trim();
                var item = context.GetCurrentRoom().GetItemsInRoom().FirstOrDefault(i => i.Name.Equals(capture, StringComparison.OrdinalIgnoreCase));
                if (ReferenceEquals(item, null) || !item.IsItemVisible())
                {
                    _consoleWriter.WriteToConsole("What are you gazing at ? Nothingness ?");
                }
                else
                {
                    _consoleWriter.WriteToConsole(item.Description);
                }
            }
        }
    }
}
