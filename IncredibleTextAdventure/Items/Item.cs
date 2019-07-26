using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanBePickedUp { get; set; }

        public abstract bool CanInteractWith(string other);
        public abstract void InteractWith(IGameContext context);
    }
}
