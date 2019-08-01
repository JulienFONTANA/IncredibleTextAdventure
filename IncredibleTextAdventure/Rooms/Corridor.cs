using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.CorridorItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Corridor : Room, IRoom
    {
        public Corridor(IEnumerable<ICorridorItem> itemsInRoom)
        {
            Name = Constants.Rooms.Corridor;
            FirstDescription = "A dark and humid corridor. You never noticed the warmth before. Is it getting hotter ?"
                               +" At the very end, you see light, and what looks like a [garden]. Behind you is the [cell] you just left.";

            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = "A dark corridor, that link your [cell] and the [garden]. " +
                          (IsItemInRoom(Constants.Items.Signs) ? 
                              "With your [lantern] you revealed strange [signs] that lit up the way to the [basement]." 
                              : string.Empty);
        }
    }
}
