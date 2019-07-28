using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Characters
{
    public interface IPlayer
    {
        void AddToInventory(IItem item);
        bool UseFromInventory(IItem item);
        string DisplayInventory();
        IItem GetItemFromInventory(string name);

        IRoom GetPlayerLocalisation();
        void SetPlayerLocalisation(IRoom newLocalisation);
        string GetPlayerStartingLocalisation();
    }
}