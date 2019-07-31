using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenShedItems
{
    public class LanternWithoutAlcohol : Item, IGardenShedItem
    {
        public LanternWithoutAlcohol()
        {
            Name = Constants.Items.LanternWithoutAlcohol;
            Description = "A tempest [lantern]. Great to use in dark places." 
                        + "Too bad there isn't any [alcohol] inside to lit it up.";
            CanBePickedUp = true;
        }
    }
}
