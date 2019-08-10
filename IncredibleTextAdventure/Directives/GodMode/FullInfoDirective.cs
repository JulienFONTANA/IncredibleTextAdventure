using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace IncredibleTextAdventure.Directives.GodMode
{
    public class FullInfoDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IRoom[] _allRooms;

        private const string CmdPattern = "^(full info)";
        private const string FullPattern = "^(full info)[ \t]?(?<capture>(.*))";

        public FullInfoDirective(IConsoleWriter consoleWriter,
            IRoom[] allRooms)
        {
            _consoleWriter = consoleWriter;
            _allRooms = allRooms;
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, IGameContext context)
        {
            var match = Regex.Match(cmd, FullPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var capture = match.Groups["capture"].Value.Trim();

                var roomToGetInfoFrom = _allRooms.FirstOrDefault(x => x.Name.EqualsIgnoreCase(capture));
                if (ReferenceEquals(roomToGetInfoFrom, null))
                {
                    _consoleWriter.WriteToConsole($"No room named {capture}. ");
                    return;
                }

                DisplayRoomInfo(roomToGetInfoFrom);
            }
        }

        private void DisplayRoomInfo(IRoom room)
        {
            var itemList = "";
            var itemsInRoom = room.GetItemsInRoom();
            foreach (var item in itemsInRoom)
            {
                itemList += item.Name + ", " + Environment.NewLine;
            }

            var linkedRoomList = "";
            var linkedRooms = room.GetLinkedRooms();
            foreach (var link in linkedRooms)
            {
                if (link.GetAccessibility())
                {
                    linkedRoomList += link.Name + ", " + Environment.NewLine;
                }
                else
                {
                    linkedRoomList += link.Name + " !!!blocked!!!, " + Environment.NewLine;
                }
            }

            var directivesList = "";
            var allDirectives = room.GetSpecialDirectives();
            foreach (var directive in allDirectives)
            {
                directivesList += directive.GetType().Name + ", " + Environment.NewLine;
            }

            var roomInfo = $"[Room Name]  => {room.Name}" + Environment.NewLine +
                           $"[Room Items] => {itemList.Remove(itemList.Length - 4)}" + Environment.NewLine +
                           $"[Linked Rooms] => {linkedRoomList.Remove(linkedRoomList.Length - 4)}" + Environment.NewLine +
                           (directivesList.Length > 4 ?
                               $"[Directives] => {directivesList.Remove(directivesList.Length - 4)}" :
                               string.Empty);

            _consoleWriter.WriteToConsole(roomInfo);
        }
    }
}
