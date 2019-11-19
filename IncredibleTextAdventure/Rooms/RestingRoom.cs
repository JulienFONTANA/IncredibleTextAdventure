using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.RestingRoomItems;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class RestingRoom : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public RestingRoom(ILanguageConst languageConst,
            IEnumerable<IRestingRoomItem> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.RestingRoomName;
            FirstDescription = _languageConst.RestingRoomFirstDescription;
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.RestingRoomDescription;
        }
    }
}
