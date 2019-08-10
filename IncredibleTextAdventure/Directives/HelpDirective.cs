using System;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class HelpDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private const string CmdPattern = "^(help|\\?)";

        private static bool _firstTime = true;

        public HelpDirective(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, IGameContext context)
        {
            if (_firstTime)
            {
                _consoleWriter.WriteToConsole(FirstTimeHelpText);
                _firstTime = false;
            }

            _consoleWriter.WriteToLine("These are some commands you could try :");
            _consoleWriter.WriteToLine("[go] to <place> - go to any visited place");
            _consoleWriter.WriteToLine("[pick] <object>");
            _consoleWriter.WriteToLine("[open] <door>");
            _consoleWriter.WriteToLine("[look] at <element>");
            _consoleWriter.WriteToLine("[use] <object> on <other>");
            _consoleWriter.WriteToLine("[inventory] - display your inventory");
            _consoleWriter.WriteToLine("[info] - gives room description");
            _consoleWriter.WriteToConsole("[where] - gives room name");

            if (_firstTime)
            {
                _consoleWriter.WriteToConsole("Good luck !");
            }
        }

        private const string FirstTimeHelpText =
            "Hello, and welcome to [IncredibleTextAdventure]. This text-based game is inspired by MS-DOS / AppleII games that " +
            "existed in the 1970-1990's. Here, [you] are the hero. It it your role to try to [interact] with your surroundings, " +
            "and ultimately to uncover [all the secrets] from the game ! Note that some words will be [===> highlighted <===] " +
            "a little, to help you. ";
    }
}
