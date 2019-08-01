using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.BasementItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Basement : Room, IRoom
    {
        public Basement(IEnumerable<IBasementItem> itemsInRoom)
        {
            Name = Constants.Rooms.Basement;
            FirstDescription = "The unreal blue light from the [corridor] is even dimmer here in the [basement]. " +
                               "Your eyes can't really get what's around you, but what looks like [weird tools] are " +
                               "hanging from walls and ceiling. As you search the room, you make a heavy sheet falls, " +
                               "revealing a magnificent [ruby ring] that colors the room with vibrant purple color. ";

            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = "The light from the [corridor] is even dimmer here in the [basement]. " +
                          "What looks like [weird tools] are hanging from walls and ceiling. " +
                          (IsItemInRoom(Constants.Items.RubyRing) ? 
                              "A splendid [ruby ring] is on display on a table. " :
                              "You start to feel like you shouldn't be here anymore...");
        }
    }
}