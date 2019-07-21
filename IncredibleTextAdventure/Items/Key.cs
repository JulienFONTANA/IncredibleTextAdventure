namespace IncredibleTextAdventure.Items
{
    public class Key : Item, IItem
    {
        public Key()
        {
            Name = "Key";
            Description = "A rusty copper key, green and heavy !";
            CanBePickedUp = true;
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
