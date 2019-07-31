using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.BarItems
{
    public class AlcoholDispenser : Item, IBarItem
    {
        public AlcoholDispenser()
        {
            Name = Constants.Items.AlcoholDispenser;
            Description = "An weird looking machinery, in a corner. Through a tube, one can fill a recipient with alcohol. " 
                + "It smells more like [flammable oil] than drinkable spirit.";
        }
    }
}
