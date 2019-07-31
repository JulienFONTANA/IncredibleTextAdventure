using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives.GodMode
{
    public class TeleportDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IRoom[] _allRooms;

        private const string CmdPattern = "^(tp|teleport)";
        private const string FullPattern = "^(tp|teleport)[ \t]?(to)?[ \t]?(?<capture>(.*))";

        public TeleportDirective(IConsoleWriter consoleWriter,
            IRoom[] allRooms)
        {
            _consoleWriter = consoleWriter;
            _allRooms = allRooms;
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

                var roomToGo = _allRooms.FirstOrDefault(x => x.Name.EqualsIgnoreCase(capture));
                if (ReferenceEquals(roomToGo, null))
                {
                    _consoleWriter.WriteToConsole("You can't go there.");
                    return;
                }

                context.GetPlayer().SetPlayerLocalisation(roomToGo);
                if (roomToGo.IsFirstTimePlayerEntersRoom())
                {
                    _consoleWriter.WriteToConsole(roomToGo.FirstDescription);
                }
                else
                {
                    _consoleWriter.WriteToConsole(roomToGo.Description);
                }
            }
        }
    }
}
