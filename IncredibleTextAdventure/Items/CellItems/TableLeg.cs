using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.CellItems
{
    public class TableLeg : Item, ICellItem
    {
        public TableLeg()
        {
            Name = Constants.Items.TableLeg;
            Description = "A [table leg]. Square, and long enough to be used as a lever maybe ?";
            IsVisible = false;
            CanBePickedUp = true;
        }
    }
}