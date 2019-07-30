using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class EmptyBottle : Item, IBarItem
    {
        public EmptyBottle()
        {
            Name = Constants.Items.EmptyBottle;
            Description = "An old whiskey, [bottle], but it's empty. And clean !";
            CanBePickedUp = true;
        }
    }
}
