using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.ComputerRoomItems;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class ComputerRoom : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public ComputerRoom(ILanguageConst languageConst,
            IEnumerable<IComputerRoomItem> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.ComputerRoomName;
            FirstDescription = _languageConst.ComputerRoomFirstDescription;
            IsRoomAccessible = true; // TODO change final room accessibility
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.ComputerRoomDescription;
        }
    }
}
