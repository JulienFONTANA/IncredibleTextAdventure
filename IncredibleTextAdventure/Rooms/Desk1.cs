using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk1 : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public Desk1(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.DeskOneName;
            FirstDescription = _languageConst.DeskOneFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.DeskOneDescription;
        }
    }
}
