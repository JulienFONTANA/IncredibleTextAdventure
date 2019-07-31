using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class LeatherChairs : Item, IBarItem
    {
        public LeatherChairs()
        {
            Name = Constants.Items.LeatherChairs;
            Description = "Very comfy looking [leather chairs], made of robust yet torn leather.";
        }
    }
}
