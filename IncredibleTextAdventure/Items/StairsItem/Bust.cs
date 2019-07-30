using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.StairsItem
{
    public class Bust : Item, IStairsItem
    {
        public Bust()
        {
            Name = Constants.Items.Bust;
            Description = "WIP";
            CanBePickedUp = false;
        }
    }
}
