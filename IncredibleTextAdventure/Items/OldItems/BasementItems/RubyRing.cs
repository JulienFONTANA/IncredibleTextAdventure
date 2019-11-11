using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BasementItems
{
    public class RubyRing : Item, IBasementItem
    {
        public RubyRing()
        {
            Name = Constants.Items.RubyRing;
            Description = "An expensive looking [ruby ring], which hypnotizes you with its fiery red hues. What a wonder !";
            CanBePickedUp = true;
        }
    }
}
