namespace IncredibleTextAdventure.Items
{
    public class Table : Item, IItem
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

        public override void InteractWith(IItem objectToUse)
        {
            return;
        }
    }
}
