using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenShedItems
{
    public class Windows : Item, IGardenShedItem
    {
        public Windows()
        {
            Name = Constants.Items.Windows;
            Description = "The view is blocked by trees, yet you can see part the [garden]. " 
                        + "There are obviously other rooms linked to the garden, you're sure of it now.";
        }
    }
}
