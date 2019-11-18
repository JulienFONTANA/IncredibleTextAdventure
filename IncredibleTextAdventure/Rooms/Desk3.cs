using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk3 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk3(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskThreeName;
            FirstDescription = _languageConst.DeskThreeFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskThreeDescription;
        }
    }
}
