using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.LoungeItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Lounge : Room, IRoom
    {
        public Lounge(IEnumerable<ILoungeItem> itemsInRoom)
        {
            Name = Constants.Rooms.Lounge;
            FirstDescription = "";
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = "[Stairs], from the [garden] to the [garden shed]. A marble [bust] greets you half-way from the top. " +
                          (IsItemInRoom(Constants.Items.Note) ?
                              "The [note] is still behind the sculpture. " :
                              string.Empty);
        }
    }
}