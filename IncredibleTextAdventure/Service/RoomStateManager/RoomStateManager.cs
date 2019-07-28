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



//var room = context.GetCurrentRoom();
//room.Description = @"In front of you is an open [door], leading to a [corridor]. " 
//+"In a corner is a small [table], made of crude wood.";
//context.GetRoom("corridor").SetAccessibility();