using IncredibleTextAdventure.ITAConsole;
using System;

namespace IncredibleTextAdventure.Items
{
    public class Door : Item, IItem
    {
        private IConsoleWriter ConsoleWriter { get; set; }

        public Door()
        {
            Name = "Door";
            Description = "It looks like a cell door. What might be on the other side?";
            CanBePickedUp = false;

            ConsoleWriter = new ConsoleWriter();
        }

        public override bool CanInteractWith(string other)
        {
            return other.Equals("key", StringComparison.OrdinalIgnoreCase);
        }

        public override void InteractWith(IItem objectToUse)
        {
            ConsoleWriter.WriteToConsole("The doors unlocks, and opens on a dark corridor...");
        }
    }
}
