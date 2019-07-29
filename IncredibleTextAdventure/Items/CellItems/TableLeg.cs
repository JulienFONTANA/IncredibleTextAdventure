namespace IncredibleTextAdventure.Items.CellItems
{
    public class TableLeg : Item, ICellItem
    {
        public TableLeg()
        {
            Name = "TableLeg";
            Description = "A [table leg]. Square, and long enough to be used as a lever maybe ?";
            IsVisible = false;
            CanBePickedUp = true;
        }
    }
}