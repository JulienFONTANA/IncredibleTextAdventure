using System;
using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.ITAConsole;

namespace IncredibleTextAdventure.Directives.Action
{
    public class HelpDirective : IDirective
    {
        private IConsoleWriter _consoleWriter;

        public HelpDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void Execute(IPlayer player)
        {
            _consoleWriter.WriteToConsole("Here to fill for now on. Sorry !");
        }

        public bool CanApply(string cmd)
        {
            return cmd.Equals("Help", StringComparison.OrdinalIgnoreCase) 
                || cmd.Equals("H", StringComparison.OrdinalIgnoreCase) 
                || cmd.Equals("?", StringComparison.OrdinalIgnoreCase);
        }
    }
}
