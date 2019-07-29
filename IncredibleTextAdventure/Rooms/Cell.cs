using System.Collections.Generic;
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
            Name = "Cell";
            FirstDescription = "You wake up with simple clothes in a small room. The walls are grey and smooth. "
                              + "Your eyes slowly gets used to darkness, and the shape of a [door] starts to form in front of you. In a corner "
                              + "is a small [table], made of crude wood. A metal [key] was put here on display.";

            IsAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);

            SpecialDirectives = specialCellDirectives;
        }

        public override void UpdateDescription()
        {
            Description = (IsAccessibile("Corridor") ? "In front of you, the doors to the [corridor] lies open. " : "In front of you is a closed, heavy [door]. ")
                          + (IsItemInRoom("Table") ? "In a corner is a small [table], made of crude wood. " : "Pieces of the table lies everywhere... ")
                          + (IsItemInRoom("Key") ? "A metal [key] was put here on display, almost as if someone wanted you to [pick] it up." : "");
        }
    }
}
