using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.StairsItem;
using System.Collections.Generic;

namespace IncredibleTextAdventure.Rooms
{
    public class Stairs : Room, IRoom
    {
        public Stairs(IEnumerable<IStairsItem> itemsInRoom)
        {
            Name = Constants.Rooms.Stairs;
            FirstDescription = "A long, narrow and steep flight of [stairs], lit by small windows, led up to a [garden shed]. "
                               + "Each step, while well maintained, start to be smooth and slippery, as if well used. "
                               + "As you climb up, you come across a marble [bust], but can't say from whom. "
                               + "Climbing is made easy by a small wind, coming from the Garden";
            Description = "[Stairs], from the [garden] to the [garden shed]";
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = "[Stairs], from the [garden] to the [garden shed]. A marble [bust] greets you half-way from the top. ";
            // TODO - write dynamic info
            //+ (IsItemInRoom(Constants.Items.Note) ? "The [note] is " : string.Empty);
        }
    }
}
