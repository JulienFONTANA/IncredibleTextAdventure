using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.StairsItem
{
    public class Bust : Item, IStairsItem
    {
        public Bust()
        {
            Name = Constants.Items.Bust;
            Description = "The crystal [bust] of a woman. It is not polished nor realistic, yet " 
                          + "you stop at the impression of intelligence and grace that emanates from it. " 
                          + "You suddenly notice a [note] behind it.";
        }
    }
}
