namespace IncredibleTextAdventure.Items
{
    public class Table : Item, IItem
    {
        public Table()
        {
            Name = "Table";
            Description = "A wooden table. Of course, one of the legs is shorter.";
            CanBePickedUp = false;
        }
    }
}
