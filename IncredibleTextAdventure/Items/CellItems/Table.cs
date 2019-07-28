namespace IncredibleTextAdventure.Items.CellItems
{
    public class Table : Item, ICellItem
    {
        public Table()
        {
            Name = "Table";
            Description = "A crude wooden [table]. Of course, one of the legs is shorter.";
            CanBePickedUp = false;
        }

        public override bool CanInteractWith(string other)
        {
            return false;
        }
    }
}
