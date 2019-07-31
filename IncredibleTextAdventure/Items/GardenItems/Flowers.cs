using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class Flowers : Item, IGardenItem
    {
        public Flowers()
        {
            Name = Constants.Items.Flowers;
            Description = "Magnificent [flowers]. The petals looks almost as if made of colorful glass...";
            CanBePickedUp = true;
        }
    }
}
