using System.Collections.Generic;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public interface IRoom
    {
        string Description { get; set; }
        string FirstDescription { get; set; }
        bool IsAccessible { get; set; }
        bool IsFirstTime { get; set; }
        string Name { get; set; }

        List<IItem> GetItemsInRoom();
        List<string> GetLinkedRooms();
        bool IsFirstTimePlayerEntersRoom();
        void RemoveItemFromRoom(string itemName);
    }
}