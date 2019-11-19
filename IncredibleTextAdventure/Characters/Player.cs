using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Characters
{
    public class Player : IPlayer
    {
        private List<IItem> Inventory { get; }
        private IRoom Location { get; set; }
        private readonly ILanguageConst _languageConst;
        private HashSet<IRoom> VisitedRooms { get; }

        private readonly IConsoleWriter _consoleWriter;

        private readonly string _startingLocation;

        public Player(IConsoleWriter consoleWriter, ILanguageConst languageConst)
        {
            Inventory = new List<IItem>();
            VisitedRooms = new HashSet<IRoom>();

            _consoleWriter = consoleWriter;
            _languageConst = languageConst;
            _startingLocation = _languageConst.OpenSpaceName;
        }

        public void AddToInventory(IItem item, bool verbose = true)
        {
            Inventory.Add(item);
            if (verbose)
            {
                // TODO - VOVF
                _consoleWriter.WriteToConsole($"Added [{item.Name}] to your inventory !");
            }
        }

        public bool UseFromInventory(IItem item)
        {
            if (Inventory.Contains(item))
            {
                return Inventory.Remove(item);
            }
            // TODO - VOVF
            throw new ArgumentException($"Item [{item.Name}] doesn't belong to player inventory !");
        }

        public string DisplayInventory()
        {
            if (Inventory.Count == 0)
            {
                return _languageConst.EmptyInventory;
            }
            // TODO - VOVF
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
            return _startingLocation;
        }

        public HashSet<IRoom> GetPlayerVisitedRooms()
        {
            return VisitedRooms;
        }
    }
}
