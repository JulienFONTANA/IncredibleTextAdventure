using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class Fountain : Item, IGardenItem
    {
        public Fountain()
        {
            Name = Constants.Items.Fountain;
            Description = "A huge fountain, depicting gods and demons dancing together... "
                        + "The traces of running water have left marks, but asof now, the whole monument is dry.";
        }
    }
}
