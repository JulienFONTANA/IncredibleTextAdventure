using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk2 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk2(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskTwoName;
            FirstDescription = _languageConst.DeskTwoFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskTwoDescription;
        }
    }
}
