using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class Flowers : Item, IGardenItem
    {
        public Flowers()
        {
            Name = Constants.Items.Flower;
            Description = "Magnificent flowers. The petals looks almost as if made of colorfull glass...";
            CanBePickedUp = true;
        }
    }
}
