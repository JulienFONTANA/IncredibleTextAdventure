using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items.OtherItems;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class AlcoholDispenser : Item, IBarItem
    {
        public AlcoholDispenser()
        {
            Name = Constants.Items.AlcoholDispenser;
            Description = "An weird looking machinery, in a corner. Through a tube, one can fill a recipient with alcohol. " 
                + "But to be honest, it smells more like [flammable oil] than drinkable spirit. ";
        }

        public override bool CanInteractWith(string other)
        {
            return other.EqualsIgnoreCase(Constants.Items.LanternWithoutAlcohol);
        }

        public override string InteractWith(IGameContext context)
        {
            const string result = "You fill the [lantern] with alcohol. You turn the light on with a simple push of a button. " +
                                  "The produced light is surreal, and seems to show more than meets the eye with natural light. " +
                                  "The shadows seems to flee from it. ";
            context.GetPlayer().AddToInventory(new Lantern(), false);
            return result;
        }
    }
}
