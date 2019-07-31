using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.GardenShedItems
{
    public class Mechanism : Item, IGardenShedItem
    {
        public Mechanism()
        {
            Name = Constants.Items.Mechanism;
            Description = "A complex copper [mechanism]. While you don't really know what's it for, a glass opening " 
                        + "in one of the tubes shows water. Maybe this is the [fountain's] water supply ? " 
                        + "In any case, you quickly find out that the main [lever] is missing.";
        }
    }
}
