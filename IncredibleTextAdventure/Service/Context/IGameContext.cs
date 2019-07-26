using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Service.Context
{
    public interface IGameContext
    {
        bool Command(string cmd);
        IRoom GetCurrentRoom();
        IRoom GetRoom(string room);
        IPlayer GetPlayer();
    }
}