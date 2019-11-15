using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public class OpenSpace : Room, IRoom
    {
        public OpenSpace()
        {
            Name = Constants.Rooms.OpenSpace;
            FirstDescription = "Open Space";
            ItemsInRoom = new List<IItem>();
        }

        public override void UpdateDescription()
        {
            Description = "Hello again";
        }
    }
}
