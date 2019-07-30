using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.CorridorItems
{
    public class Signs : Item, ICorridorItem
    {
        public Signs()
        {
            Name = Constants.Items.Signs;
            Description = "Weird luminescent signs covers the walls now in an electric blue color. "
                         +"The path to the [basement] is now illuminated...";
            IsVisible = false;
        }
    }
}
