using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class Lantern : Item, IBarItem
    {
        public Lantern()
        {
            Name = Constants.Items.Lantern;
            Description = "A tempest [lantern]. Great to use in dark places."
                          + "Filled with enough alcohol to last for hours ! "
                          + "It's light is good enough to see tens of meter away.";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}
