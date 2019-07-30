using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BasementItems
{
    public class WeirdTools : Item, IBasementItem
    {
        public WeirdTools()
        {
            Name = Constants.Items.WeirdTools;
            Description = "Really [weird tools]. Nothing about these makes sens : neither their shapes, color, nor smells. " 
                        + "They seem out of this world. You can't even say what they are made of ! Better not touch them.";
        }
    }
}
