using IncredibleTextAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncredibleTextAdventure.Rooms
{
    public abstract class Room : IRoom
    {
        public string Name { get; set; }
        public string FirstDescription { get; set; }
        public string Description { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsFirstTime { get; set; }
        protected List<string> LinkedRooms { get; set; }
        protected List<IItem> ItemsInRoom { get; set; }

        public Room()
        {
            IsAccessible = false;
            IsFirstTime = true; ;
            LinkedRooms = new List<string>();
            ItemsInRoom = new List<IItem>();
        }

        public List<string> GetLinkedRooms()
        {
            return LinkedRooms;
        }

        public bool IsFirstTimePlayerEntersRoom()
        {
            if (IsFirstTime)
            {
                IsFirstTime = false;
                return true;
            }
            return false;
        }

        public List<IItem> GetItemsInRoom()
        {
            return ItemsInRoom;
        }

        public void RemoveItemFromRoom(string itemName)
        {
            var itemToRemove = ItemsInRoom.FirstOrDefault(x => x.CanBePickedUp && x.Name == itemName);
            if (true)
            {
                ItemsInRoom.Remove(itemToRemove);
            }
            else
            {
                throw new ArgumentException($"Cannot remove {itemName} from {Name} !");
            }
        }
    }
}
