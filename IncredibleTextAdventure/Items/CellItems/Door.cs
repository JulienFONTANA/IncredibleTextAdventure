﻿using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service.Context;
using System;

namespace IncredibleTextAdventure.Items
{
    public class Door : Item, IItem
    {
        private IConsoleWriter ConsoleWriter { get; set; }

        public Door()
        {
            Name = "Door";
            Description = "It looks like a cell [door]. What might be on the other [side]?";
            CanBePickedUp = false;

            ConsoleWriter = new ConsoleWriter();
        }

        public override bool CanInteractWith(string other)
        {
            return other.Equals("key", StringComparison.OrdinalIgnoreCase);
        }

        public override void InteractWith(IGameContext context)
        {
            ConsoleWriter.WriteToConsole("The doors [unlocks], and opens on a dark [corridor]...");
            Description = "An open cell door, which opens on a [corridor]. Doesn't looks that heavy now...";
            var room = context.GetCurrentRoom();
            room.Description = @"In front of you is an open [door], leading to a [corridor]. " 
                               +"In a corner is a small [table], made of crude wood.";
            context.GetRoom("corridor").IsAccessible = true;
        }
    }
}