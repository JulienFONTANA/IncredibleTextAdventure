using IncredibleTextAdventure.Items;

namespace IncredibleTextAdventure.Characters
{
    public interface IPlayer
    {
        void AddToInventory(IItem item);
        bool UseFromInventory(IItem item);
        string DisplayInventory();
        IItem GetItemFromInventory(string name);

        string GetPlayerLocalisation();
        void SetPlayerLocalisation(string newLocalisation);
    }
}