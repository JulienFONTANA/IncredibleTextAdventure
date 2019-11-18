using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class OpenSpace : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public OpenSpace(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.OpenSpaceName;
            FirstDescription = _languageConst.OpenSpaceFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.OpenSpaceDescription;
        }
    }
}
