using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk4 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk4(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskFourName;
            FirstDescription = _languageConst.DeskFourFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskFourDescription;
        }
    }
}
