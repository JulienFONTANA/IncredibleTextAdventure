using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.CellItems
{
    public class Key : Item, ICellItem
    {
        public Key()
        {
            Name = "Key";
            Description = "A rusty copper [key], green and heavy !";
            CanBePickedUp = true;
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
