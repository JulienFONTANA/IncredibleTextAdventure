using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public class Desk4 : Room, IRoom
    {
        public Desk4()
        {
            Name = Constants.Rooms.DeskFour;
            FirstDescription = "";
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = "";
        }
    }
}
