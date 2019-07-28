using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanBePickedUp { get; set; }

        public abstract bool CanInteractWith(string other);

        public virtual string InteractWith(IGameContext context)
        {
            return string.Empty;
        }

        public virtual string BlocksPathTo()
        {
            return string.Empty;
        }
    }
}
