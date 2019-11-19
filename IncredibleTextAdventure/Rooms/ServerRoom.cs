using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.ServerRoomItems;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class ServerRoom : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public ServerRoom(ILanguageConst languageConst,
            IEnumerable<IServerRoomItem> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.ServerRoomName;
            FirstDescription = _languageConst.ServerRoomFirstDescription;
            IsRoomAccessible = true; // TODO Change this accessibility ?
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.ServerRoomDescription;
        }
    }
}
