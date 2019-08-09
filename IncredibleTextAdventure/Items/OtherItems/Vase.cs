using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.OtherItems
{
    public class Vase : Item, IItem
    {
        public Vase()
        {
            Name = Constants.Items.Vase;
            Description = "The [empty bottle] you had is now filled with water. Funny, il now looks like a [vase]. ";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}
