using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.StairsItem;
using System.Collections.Generic;
using IncredibleTextAdventure.Directives.Stairs;

namespace IncredibleTextAdventure.Rooms
{
    public class Stairs : Room, IRoom
    {
        public Stairs(IEnumerable<IStairsItem> itemsInRoom,
            IStairsDirective[] specialCellDirectives)
        {
            Name = Constants.Rooms.Stairs;
            FirstDescription = "A long, narrow and steep flight of [stairs], lit by small windows, led up to a [garden shed]. "
                               + "Each step, while well maintained, start to be smooth and slippery, as if well used. "
                               + "As you climb up, you come across a marble [bust], but can't say from whom. "
                               + "Climbing is made easy by a small wind, coming from the Garden";
            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
            SpecialDirectives = specialCellDirectives;
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
