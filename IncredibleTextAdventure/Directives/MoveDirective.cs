using System;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public class MoveDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
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

                var currentRoom = context.GetCurrentRoom();
                if (capture.EqualsIgnoreCase(currentRoom.Name))
                {
                    _consoleWriter.WriteToConsole($"You are already in the [{capture}].");
                    return;
                }

                var roomToGo = currentRoom.GetLinkedRooms().FirstOrDefault(x => x.Name.EqualsIgnoreCase(capture));
                if (ReferenceEquals(roomToGo, null))
                {
                    _consoleWriter.WriteToConsole("You can't go there.");
                    return;
                }

                var nextRoom = context.GetRoom(roomToGo);
                if (ReferenceEquals(nextRoom, null))
                {
                    _consoleWriter.WriteToConsole("You can't go there.");
                }
                else if (!context.GetRoom(roomToGo).GetAccessibility())
                {
                    _consoleWriter.WriteToConsole($"You can't access [{roomToGo.Name}] !");
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

        private void MoveToRoom(IGameContext context, IRoom roomToGo)
        {
            var room = context.GetRoom(roomToGo);
            context.GetPlayer().SetPlayerLocalisation(roomToGo);
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
