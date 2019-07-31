using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.LoungeItems
{
    public class Chimney : Item, ILoungeItem
    {
        public Chimney()
        {
            Name = Constants.Items.Chimney;
            Description = "A classy rocky [chimney]. An yellow fire comes out of strange rocks. "
                + "The chimney itself seems magical, and protects you from the incredible heat coming " 
                + "out of those flames. The lights it produces is warm and soft.";
        }
    }
}
