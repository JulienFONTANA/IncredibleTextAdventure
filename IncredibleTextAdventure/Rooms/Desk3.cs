using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk3 : Room, IRoom
    {
        public Desk3()
        {
            Name = Constants.Rooms.DeskThree;
            FirstDescription = "";
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = "";
        }
    }
}
