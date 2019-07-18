using System;
using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.ITAConsole;

namespace IncredibleTextAdventure.Directives.Action
{
    public class LookDirective : IDirective
    {
        private IConsoleWriter _consoleWriter;

        public LookDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void Execute(IPlayer player)
        {
            _consoleWriter.WriteToConsole("WIP");
            //_consoleWriter.WriteToConsole(item.Description);
        }

        public bool CanApply(string cmd)
        {
            return cmd.Equals("Look", StringComparison.OrdinalIgnoreCase);
        }
    }
}
