using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items
{
    public interface IItem
    {
        string Description { get; set; }
        string Name { get; set; }
        bool CanBePickedUp { get; set; }

        bool CanInteractWith(string other);
        string InteractWith(IGameContext context);
        string BlocksPathTo();
        bool IsItemVisible();
        void SetItemVisibility(bool visible);
    }
}