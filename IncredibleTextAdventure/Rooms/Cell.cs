using System.Collections.Generic;
using IncredibleTextAdventure.Items.CellItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Cell : Room, IRoom
    {
        public Cell(ICellItem[] itemsInRoom)
        {
            Name = "Cell";
            FirstDescription = @"You wake up with simple clothes in a small room.The walls are grey and smooth. "
                              + "Your eyes slowly gets used to darkness, and the shape of a [door] starts to form in front of you. In a corner "
                              + "is a small [table], made of crude wood. A metal [key] was put here on display.";

            Description = @"In front of you is a closed, heavy [door]. In a corner is a small [table], made of crude wood. "
                          +"A metal [key] was put here on display, almost as if someone wants you to pick it up.";

            IsAccessible = true;
            LinkedRooms = new List<string> { "Corridor" };
            ItemsInRoom = itemsInRoom;
        }
    }
}
