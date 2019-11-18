using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class ServerRoom : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public ServerRoom(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.ServerRoomName;
            FirstDescription = _languageConst.ServerRoomFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.ServerRoomDescription;
        }
    }
}
