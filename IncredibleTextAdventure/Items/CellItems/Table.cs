using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.CellItems
{
    public class Table : Item, ICellItem
    {
        public Table()
        {
            Name = Constants.Items.Table;
            Description = "A crude wooden [table]. Of course, one of the legs is shorter. It doesn't look very solid, " +
                          "and could easily be [broken]. ";
        }
    }
}
