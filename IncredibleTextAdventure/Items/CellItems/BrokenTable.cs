namespace IncredibleTextAdventure.Items.CellItems
{
    public class BrokenTable : Item, ICellItem
    {
        public BrokenTable()
        {
            Name = "BrokenTable";
            Description = "A [broken table]. There are some pieces of wood everywhere now. One of the square [table leg] is still intact though.";
            IsVisible = false;
        }
    }
}
