using System;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class MoveDirective : IDirective
    {
        private IConsoleWriter _consoleWriter;
        private const string CmdPattern = @"^(move|go)";
        private const string FullPattern = @"^(move|go)[ \t]?(to)?[ \t]?(?<capture>(.*))";

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
                var capture = match.Groups["capture"].Value.Trim();

                var roomToGo = context.GetCurrentRoom().GetLinkedRooms().FirstOrDefault(x => x.Equals(capture, StringComparison.OrdinalIgnoreCase));
                if (ReferenceEquals(roomToGo, null))
                {
                    _consoleWriter.WriteToConsole("You can't go there.");
                }

                if (!context.GetRoom(roomToGo).IsAccessible)
                {
                    _consoleWriter.WriteToConsole($"You can't access {roomToGo} !");
                }
                else
                {
                    MoveToRoom(context, roomToGo);
                }
            }
            else
            {
                _consoleWriter.WriteToConsole("You can't go there.");
            }
        }

        private void MoveToRoom(GameContext context, string roomToGo)
        {
            var room = context.GetRoom(roomToGo);
            context.Player.SetPlayerLocalisation(roomToGo);
            if (room.IsFirstTimePlayerEntersRoom())
            {
                _consoleWriter.WriteToConsole(room.FirstDescription);
            }
            else
            {
                _consoleWriter.WriteToConsole(room.Description);
            }
        }
    }
}
