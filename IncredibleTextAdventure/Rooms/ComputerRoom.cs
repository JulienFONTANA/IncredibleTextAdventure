using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Rooms
{
    public class ComputerRoom : Room, IRoom
    {
        private readonly ILanguageConst _languageConst;

        public ComputerRoom(ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            Name = _languageConst.ComputerRoomName;
            FirstDescription = _languageConst.ComputerRoomFirstDescription;
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = _languageConst.ComputerRoomDescription;
        }
    }
}
