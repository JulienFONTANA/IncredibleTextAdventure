using System;
using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Service.RoomLinker
{
    public class RoomLinker : IRoomLinker
    {
        private readonly List<IRoom> _rooms;
        private readonly Dictionary<string, List<string>> _linkedRoomList = new Dictionary<string, List<string>>
        {
            {"Cell", new List<string> {"Corridor"}},
            {"Corridor", new List<string> {"Cell", "Garden"}},
            {"Garden", new List<string> {"Corridor"}}
        };

        public RoomLinker(IEnumerable<IRoom> rooms)
        {
            _rooms = rooms.ToList();
        }

        public void InitRoomConnection()
        {
            foreach (var roomName in _linkedRoomList.Keys)
            {
                var room = _rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(roomName));

                if (ReferenceEquals(room, null))
                {
                    throw  new ArgumentNullException($"Unable to find room named {roomName}.");
                }

                var linkedRooms = new List<IRoom>();
                foreach (var roomToLink in _linkedRoomList[roomName])
                {
                    linkedRooms.Add(_rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(roomToLink)));
                }

                room.SetLinkedRoom(linkedRooms);
            }
        }
    }
}
