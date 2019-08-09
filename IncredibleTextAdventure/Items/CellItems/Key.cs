using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.CellItems
{
    public class Key : Item, ICellItem
    {
        public Key()
        {
            Name = Constants.Items.Key;
            Description = "A rusty copper [key], green and heavy. ";
            CanBePickedUp = true;
        }
    }
}
