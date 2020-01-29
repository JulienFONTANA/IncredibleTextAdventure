using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class RestingRoom : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public RestingRoom(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.RestingRoomName;
            FirstDescription = _languageConst.RestingRoomFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.RestingRoomDescription;
        }
    }
}
