using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class WaterlessFountain : Item, IGardenItem
    {
        public WaterlessFountain()
        {
            Name = Constants.Items.WaterlessFountain;
            Description = "A huge [fountain], depicting gods and demons dancing together... "
                        + "The traces of running water have left marks, but as-of now, the whole thing is [dry]. ";
        }
    }
}
