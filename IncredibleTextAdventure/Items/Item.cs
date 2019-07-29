using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanBePickedUp { get; set; }
        protected bool IsVisible { get; set; }

        protected Item()
        {
            CanBePickedUp = false;
            IsVisible = true;
        }

        public virtual bool CanInteractWith(string other)
        {
            return false;
        }

        public virtual string InteractWith(IGameContext context)
        {
            return string.Empty;
        }

        public virtual string BlocksPathTo()
        {
            return string.Empty;
        }

        public bool IsItemVisible()
        {
            return IsVisible;
        }

        public void SetItemVisibility(bool visible)
        {
            IsVisible = visible;
        }
    }
}
