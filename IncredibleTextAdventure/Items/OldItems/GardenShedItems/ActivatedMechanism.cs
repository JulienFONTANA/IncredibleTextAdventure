using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenShedItems
{
    public class ActivatedMechanism : Item, IGardenShedItem
    {
        public ActivatedMechanism()
        {
            Name = Constants.Items.ActivatedMechanism;
            Description = "A complex copper [mechanism]. You used the [table leg] on the mechanism, and now the " +
                          "water is running again !";
        }
    }
}