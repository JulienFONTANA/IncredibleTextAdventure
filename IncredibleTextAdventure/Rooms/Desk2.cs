using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk2 : Room, IRoom
    {
        public Desk2()
        {
            Name = Constants.Rooms.DeskTwo;
            FirstDescription = "";
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = "";
        }
    }
}
