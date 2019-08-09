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
    }
}
