using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class Fountain : Item, IGardenItem
    {
        public Fountain()
        {
            Name = Constants.Items.Fountain;
            Description = "A huge [fountain], depicting gods and demons dancing together... "
                        + "The battle is even more epic as the water flows freely, cooling the air. ";
            IsVisible = false;
        }
    }
}
