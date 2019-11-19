using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.Desk2Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk2 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk2(ILanguageConst languageConst,
            IEnumerable<IDesk2Item> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskTwoName;
            FirstDescription = _languageConst.DeskTwoFirstDescription;
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskTwoDescription;
        }
    }
}
