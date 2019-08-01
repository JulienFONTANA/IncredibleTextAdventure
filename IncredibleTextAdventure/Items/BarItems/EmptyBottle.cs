using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class EmptyBottle : Item, IBarItem
    {
        public EmptyBottle()
        {
            Name = Constants.Items.EmptyBottle;
            Description = "An old whiskey [bottle], that used to be filled with putrid liquid, but it's empty now. " +
                          "A [golden key] fell from it.";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}
