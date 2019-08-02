using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.GardenShedItems;

namespace IncredibleTextAdventure.Rooms
{
    public class GardenShed : Room, IRoom
    {
        public GardenShed(IEnumerable<IGardenShedItem> itemsInRoom)
        {
            Name = Constants.Rooms.GardenShed;
            FirstDescription = "As you climb the last steps of the [stairs], you enter a wooden-walled " +
                               "room that looks like a [garden shed]. The room overlooks the [garden], which " +
                               "you can see through the [windows]. Most of the room is filled with empty rack, " +
                               "where gardening tools used to be. The only thing left is a [lantern]. " +
                               "Out of the wall, copper pipes and silent gears form a [mechanism] that lies still.";

            IsRoomAccessible = true;

            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = "From the [stairs], you enter a wooden-walled [garden shed]. The room overlooks the [garden]," +
                          " which you can see through the [windows]. " +
                          (IsItemInRoom(Constants.Items.LanternWithoutAlcohol)
                              ? "On an empty rack is a [lantern]. "
                              : "You took the [lantern] with you. ") +
                          // TODO - change this when mechanism is activated ?
                          "Out of the wall, copper pipes form a complex [mechanism].";
        }
    }
}
