using System;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Items;
using System.Collections.Generic;
using System.Linq;

namespace IncredibleTextAdventure.Rooms
{
    public abstract class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstDescription { get; set; }

        protected bool IsAccessible { get; set; }
        protected bool IsFirstTime { get; set; }
        protected List<IRoom> LinkedRooms { get; set; }
        protected List<IItem> ItemsInRoom { get; set; }
        protected IDirective[] SpecialDirectives { get; set; }

        protected Room()
        {
            IsAccessible = false;
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
            return IsAccessible;
        }

        public void SetAccessibility(bool accessible = true)
        {
            IsAccessible = accessible;
        }

        protected bool IsItemInRoom(string itemNameToLookUp)
        {
            return ItemsInRoom.Any(item => item.Name.Equals(itemNameToLookUp, StringComparison.OrdinalIgnoreCase));
        }
    }
}
