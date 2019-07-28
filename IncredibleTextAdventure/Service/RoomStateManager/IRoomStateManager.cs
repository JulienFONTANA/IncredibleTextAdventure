using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Service.RoomStateManager
{
    public interface IRoomStateManager
    {
        void OpenRoom(IRoom roomToOpen);
    }
}