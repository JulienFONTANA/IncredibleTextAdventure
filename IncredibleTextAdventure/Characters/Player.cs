﻿using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Characters
{
    public class Player : IPlayer
    {
        private List<IItem> Inventory { get; }
        private IRoom Localisation { get; set; }

        private readonly IConsoleWriter _consoleWriter;

        private const string StartingLocalisation = "cell";

        public Player(IConsoleWriter consoleWriter)
        {
            Inventory = new List<IItem>();

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
                return "Your inventory is empty...";
            }
            else if (Inventory.Count == 1)
            {
                return "Your have a " + string.Join(", ", Inventory.FirstOrDefault().Name);
            }
            else
            {
                return "Your have : " + string.Join(", ", Inventory.Select(x => x.Name));
            }
        }

        public IItem GetItemFromInventory(string name)
        {
            return Inventory.FirstOrDefault(item => item.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public IRoom GetPlayerLocalisation()
        {
            return Localisation;
        }

        public void SetPlayerLocalisation(IRoom newLocalisation)
        {
            Localisation = newLocalisation;
        }

        public string GetPlayerStartingLocalisation()
        {
            return StartingLocalisation;
        }
    }
}
