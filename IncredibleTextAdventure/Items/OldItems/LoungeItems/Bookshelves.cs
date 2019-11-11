using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.LoungeItems
{
    public class Bookshelves : Item, ILoungeItem
    {
        public Bookshelves()
        {
            Name = Constants.Items.Bookshelves;
            Description = "Huge, massive [bookshelves], filled with all kind of tomes, books and scrolls. " 
                        + "Weirdly, you can't read any of the symbols in any of the books !";
        }
    }
}
