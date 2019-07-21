namespace IncredibleTextAdventure.Items
{
    public class Door : Item, IItem
    {
        public Door()
        {
            Name = "Door";
            Description = "It looks like a cell door. What might be on the other side ?";
            CanBePickedUp = false;
        }
    }
}
