using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class Bottle : Item, IBarItem
    {
        public Bottle()
        {
            Name = Constants.Items.Bottle;
            Description = "An old whiskey [bottle], filled with putrid liquid. you don't want to carry it around... " +
                          "It makes a strange noise when you move it, as if [something] was inside. ";
        }
    }
}
