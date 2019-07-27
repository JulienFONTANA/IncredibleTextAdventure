using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class Flowers : Item, IItem
    {
        public Flowers()
        {
            Name = "Flowers";
            Description = "Magnificent flowers. The petals looks almost as if made of colorfull glass...";
            CanBePickedUp = true;
        }

        public override bool CanInteractWith(string other)
        {
            return false;
        }

        public override void InteractWith(IGameContext context)
        {
            return;
        }
    }
}
