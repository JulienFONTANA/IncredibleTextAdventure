using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items
{
    public class Flowers : Item, IItem
    {
        public Flowers()
        {
            Name = "Flowers";
            Description = "Magnificent flowers. You don't really want to pick them up...";
            CanBePickedUp = false;
        }

        public override bool CanInteractWith(string other)
        {
            return false;
        }

        public override void InteractWith(IGameContext context)
        {
            return;
        }
    }
}
