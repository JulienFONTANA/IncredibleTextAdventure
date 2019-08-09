using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

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

        public override bool CanInteractWith(string other)
        {
            return other.EqualsIgnoreCase(Constants.Items.Flowers);
        }

        public override string InteractWith(IGameContext context)
        {
            const string result = "The [vase] and the [flowers] goes well together. You now have a [bouquet] ! ";
            context.GetPlayer().UseFromInventory(this);
            context.GetPlayer().AddToInventory(new Vase(), false);
            return result;
        }
    }
}
