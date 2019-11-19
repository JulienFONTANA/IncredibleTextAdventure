using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.Desk1Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk1 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk1(ILanguageConst languageConst,
            IEnumerable<IDesk1Item> itemsInRoom)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskOneName;
            FirstDescription = _languageConst.DeskOneFirstDescription;
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskOneDescription;
        }
    }
}
