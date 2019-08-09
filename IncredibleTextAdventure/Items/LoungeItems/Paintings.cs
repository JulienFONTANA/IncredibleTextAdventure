using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.LoungeItems
{
    public class Paintings : Item, ILoungeItem
    {
        public Paintings()
        {
            Name = Constants.Items.Paintings;
            Description = "Sad [paintings], almost only of a very young child. " 
                        + "The description reads : 'To my sweet [Emily]', gone too early. ";
        }
    }
}
