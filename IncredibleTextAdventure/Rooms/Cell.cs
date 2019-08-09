using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Directives.Cell;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.CellItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Cell : Room, IRoom
    {
        public Cell(IEnumerable<ICellItem> itemsInRoom, 
            ICellDirective[] specialCellDirectives)
        {
            Name = Constants.Rooms.Cell;
            FirstDescription = "You wake up with simple clothes in a small room. The walls are grey and smooth. "
                              + "Your eyes slowly gets used to darkness, and the shape of a [door] starts to form in front of you. In a corner "
                              + "is a small [table], made of crude wood, that doesn't seem very solid. A metal [key] was put here on display, " 
                              + "almost as if someone wanted you to [pick] it up. ";

            IsRoomAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
            SpecialDirectives = specialCellDirectives;
        }

        public override void UpdateDescription()
        {
            Description = (IsLinkedRoomAccessible(Constants.Rooms.Corridor) ?
                              "In front of you, the doors to the [corridor] lies open. " :
                              "In front of you is a closed, heavy [door]. ")
                          + (IsItemInRoom(Constants.Items.Table) ? 
                              "In a corner is a small [table], made of crude wood. Doesn't seem very solid. " :
                              "The [broken table] pieces are everywhere... The only complete part left is a [table leg]. ")
                          + (IsItemInRoom(Constants.Items.Key) ? 
                              "A metal [key] was put here on display, almost as if someone wanted you to [pick] it up. " :
                              string.Empty);
        }
    }
}
