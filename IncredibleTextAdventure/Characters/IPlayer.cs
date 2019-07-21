using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Characters
{
    public interface IPlayer
    {
        int xCoord { get; set; }
        int yCoord { get; set; }

        void AddToInventory(IItem item);
        bool UseFromInventory(IItem item);
        string DisplayInventory();
        void Info();
        IItem GetItemFromInventory(string name);
    }
}