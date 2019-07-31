using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BasementItems
{
    public class RubyRing : Item, IBasementItem
    {
        public RubyRing()
        {
            Name = Constants.Items.RubyRing;
            Description = "A [ruby ​​ring], which hypnotizes you with it's fiery red hues. What a wonder !";
            CanBePickedUp = true;
        }
    }
}
