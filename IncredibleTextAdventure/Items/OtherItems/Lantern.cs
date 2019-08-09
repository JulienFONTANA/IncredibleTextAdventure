using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.OtherItems
{
    public class Lantern : Item, IItem
    {
        public Lantern()
        {
            Name = Constants.Items.Lantern;
            Description = "A tempest [lantern]. Great to use in dark places. Filled with enough " +
                          "alcohol to last for hours ! It produces enough light to see tens of " +
                          "meter away. Shadows seems to flee from it.";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}
