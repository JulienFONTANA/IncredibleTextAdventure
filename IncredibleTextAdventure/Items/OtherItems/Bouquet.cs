using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.OtherItems
{
    public class Bouquet : Item, IItem
    {
        public Bouquet()
        {
            Name = Constants.Items.Bouquet;
            Description = "A [bouquet], not that impressive, made out of an [empty bottle] and some garden [flowers]. " +
                          "The petals looks more like crystal than ever, and the light going through it is incredible. ";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}