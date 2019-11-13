using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public class RestingRoom : Room, IRoom
    {
        public RestingRoom()
        {
            Name = Constants.Rooms.RestingRoom;
            FirstDescription = "";
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = "";
        }
    }
}
