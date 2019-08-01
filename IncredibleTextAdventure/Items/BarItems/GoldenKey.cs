using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class GoldenKey : Item, IBarItem
    {
        public GoldenKey()
        {
            Name = Constants.Items.GoldenKey;
            Description = "A small golden [key], masterfully crafted.";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}
