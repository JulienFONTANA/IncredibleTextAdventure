using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.Desk4Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk4 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk4(ILanguageConst languageConst,
            IEnumerable<IDesk4Item> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskFourName;
            FirstDescription = _languageConst.DeskFourFirstDescription;
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskFourDescription;
        }
    }
}
