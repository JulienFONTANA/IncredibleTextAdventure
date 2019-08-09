using System.Collections.Generic;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Characters
{
    public interface IPlayer
    {
        void AddToInventory(IItem item, bool verbose = true);
        bool UseFromInventory(IItem item);
        string DisplayInventory();
        IItem GetItemFromInventory(string name);
        IRoom GetPlayerLocation();
        void SetPlayerLocation(IRoom newLocation);
        string GetPlayerStartingLocation();
        HashSet<IRoom> GetPlayerVisitedRooms();
    }
}