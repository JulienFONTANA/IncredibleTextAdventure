using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;

namespace IncredibleTextAdventure.Characters
{
    public class Player : IPlayer
    {
        private List<IItem> Inventory { get; }
        private IRoom Location { get; set; }
        private HashSet<IRoom> VisitedRooms { get; set; }

        private readonly IConsoleWriter _consoleWriter;

        private const string StartingLocation = Constants.Rooms.Cell;

        public Player(IConsoleWriter consoleWriter)
        {
            Inventory = new List<IItem>();
            VisitedRooms = new HashSet<IRoom>();

            _consoleWriter = consoleWriter;
        }

        public void AddToInventory(IItem item)
        {
            Inventory.Add(item);
            _consoleWriter.WriteToConsole($"Added [{item.Name}] to your inventory !");
        }

        public bool UseFromInventory(IItem item)
        {
            if (Inventory.Contains(item))
            {
                return Inventory.Remove(item);
            }
            throw new ArgumentException($"Item [{item.Name}] doesn't belong to player inventory !");
        }

        public string DisplayInventory()
        {
            if (Inventory.Count == 0)
            {
                return "Your inventory is empty... ";
            }
            return "Your have : " + string.Join(", ", Inventory.Select(x => x.Name));
        }

        public IItem GetItemFromInventory(string name)
        {
            return Inventory.FirstOrDefault(item => item.Name.EqualsIgnoreCase(name));
        }

        public IRoom GetPlayerLocation()
        {
            return Location;
        }

        public void SetPlayerLocation(IRoom newLocation)
        {
            Location = newLocation;
            VisitedRooms.Add(newLocation);
            Location.UpdateDescription();
        }

        public string GetPlayerStartingLocation()
        {
            return StartingLocation;
        }

        public HashSet<IRoom> GetPlayerVisitedRooms()
        {
            return VisitedRooms;
        }
    }
}
