using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.Desk3Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk3 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk3(ILanguageConst languageConst,
            IEnumerable<IDesk3Item> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskThreeName;
            FirstDescription = _languageConst.DeskThreeFirstDescription;
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskThreeDescription;
        }
    }
}
