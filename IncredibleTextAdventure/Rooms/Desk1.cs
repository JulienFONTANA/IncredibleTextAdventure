using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk1 : Room, IRoom
    {
        public Desk1()
        {
            Name = Constants.Rooms.DeskOne;
            FirstDescription = "Desk One";
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = "Desk One";
        }
    }
}
