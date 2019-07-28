using System.Collections.Generic;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Rooms
{
    public interface IRoom
    {
        string FirstDescription { get; set; }
        string Description { get; set; }
        bool IsAccessible { get; set; }
        string Name { get; set; }

        List<IItem> GetItemsInRoom();
        List<IRoom> GetLinkedRooms();
        IDirective[] GetSpecialDirectives();
        bool IsFirstTimePlayerEntersRoom();
        void SetFirstTimeFalse();
        void RemoveItemFromRoom(IItem itemToRemove);
        void SetLinkedRoom(List<IRoom> linkedRooms);
    }
}