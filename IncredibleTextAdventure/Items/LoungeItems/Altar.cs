using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.LoungeItems
{
    public class Altar : Item, ILoungeItem
    {
        public Altar()
        {
            Name = Constants.Items.Altar;
            Description = "A small table, richly decorated with gold and precious stones. " 
                          +"Words engraved in stone reads : 'To [Emily], who loved nothing " 
                          +"more than playing in the garden, bathing in the sun, tending to [flowers]'. " 
                          +"You notice a place on the [altar], as if a piece was missing. ";
        }

        public override bool CanInteractWith(string other)
        {
            return other.EqualsIgnoreCase(Constants.Items.Bouquet);
        }

        public override string InteractWith(IGameContext context)
        {
            Description = "The [bouquet], surrounded by candles, looks really nice. The [altar] has come to life once more, ";
            const string result = "As you place the [bouquet] on the altar, candles lit up, and one of the painting start to move. " +
                                  "The little girl on it start smiling for a few seconds, then walk away. The painting is now depicts " +
                                  "an open door, leading [outside]... Free, at last ? ";
            return result;
        }

        public override string BlocksPathTo()
        {
            return Constants.Rooms.Outside;
        }
    }
}
