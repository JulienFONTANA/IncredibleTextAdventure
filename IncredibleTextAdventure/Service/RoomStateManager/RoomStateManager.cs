using System.Linq;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Service.RoomStateManager
{
    public class RoomStateManager : IRoomStateManager
    {
        private readonly IRoom[] _rooms;

        public RoomStateManager(IRoom[] rooms)
        {
            _rooms = rooms;
        }

        public void OpenRoom(IRoom roomToOpen)
        {
            _rooms.FirstOrDefault(r => r.Equals(roomToOpen))?.SetAccessibility();
        }
    }
}