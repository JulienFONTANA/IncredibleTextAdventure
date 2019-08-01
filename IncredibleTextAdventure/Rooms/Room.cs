using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Items;
using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Service;

namespace IncredibleTextAdventure.Rooms
{
    public abstract class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstDescription { get; set; }

        protected bool IsRoomAccessible { get; set; }
        protected bool IsFirstTime { get; set; }
        protected List<IRoom> LinkedRooms { get; set; }
        protected List<IItem> ItemsInRoom { get; set; }
        protected IDirective[] SpecialDirectives { get; set; }

        protected Room()
        {
            IsRoomAccessible = false;
            IsFirstTime = true;
            LinkedRooms = new List<IRoom>();
            ItemsInRoom = new List<IItem>();
            SpecialDirectives = new IDirective[] {};
        }

        public List<IRoom> GetLinkedRooms()
        {
            return LinkedRooms;
        }

        public bool IsFirstTimePlayerEntersRoom()
        {
            if (IsFirstTime)
            {
                SetFirstTimeFalse();
                return true;
            }
            return false;
        }

        public void SetFirstTimeFalse()
        {
            IsFirstTime = false;
        }

        public List<IItem> GetItemsInRoom()
        {
            return ItemsInRoom;
        }

        public IItem GetItem(string itemName)
        {
            return ItemsInRoom.FirstOrDefault(item => item.Name.EqualsIgnoreCase(itemName));
        }

        public IDirective[] GetSpecialDirectives()
        {
            return SpecialDirectives;
        }

        public void RemoveItemFromRoom(IItem itemToRemove)
        {
            ItemsInRoom.Remove(itemToRemove);
        }

        public void SetLinkedRoom(List<IRoom> linkedRooms)
        {
            LinkedRooms = linkedRooms;
        }

        public bool GetAccessibility()
        {
            return IsRoomAccessible;
        }

        public void SetAccessibility(bool accessible = true)
        {
            IsRoomAccessible = accessible;
        }

        public bool IsItemInRoom(string itemNameToLookUp)
        {
            return ItemsInRoom.Any(item => item.Name.EqualsIgnoreCase(itemNameToLookUp) && item.IsItemVisible());
        }

        public bool IsLinkedRoomAccessible(string roomNameToLookUp)
        {
            var room = LinkedRooms.FirstOrDefault(r =>r.Name.EqualsIgnoreCase(roomNameToLookUp));
            return !ReferenceEquals(room, null) && room.GetAccessibility();
        }

        public virtual void UpdateDescription() { }
    }
}
