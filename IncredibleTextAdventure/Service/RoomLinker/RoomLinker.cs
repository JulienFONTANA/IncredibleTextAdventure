using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncredibleTextAdventure.Service.RoomLinker
{
    public class RoomLinker : IRoomLinker
    {
        private readonly List<IRoom> _rooms;
        private readonly Dictionary<string, List<string>> _linkedRoomList = new Dictionary<string, List<string>>
        {
            {
                Constants.Rooms.Bar, new List<string>
                {
                    Constants.Rooms.Garden
                }
            },
            {
                Constants.Rooms.Basement, new List<string>
                {
                    Constants.Rooms.Corridor
                }
            },
            {
                Constants.Rooms.Cell, new List<string>
                {
                    Constants.Rooms.Corridor
                }
            },
            {
                Constants.Rooms.Corridor, new List<string>
                {
                    Constants.Rooms.Cell,
                    Constants.Rooms.Garden,
                    Constants.Rooms.Basement
                }
            },
            {
                Constants.Rooms.Garden, new List<string>
                {
                    Constants.Rooms.Corridor,
                    Constants.Rooms.Stairs,
                    Constants.Rooms.Bar,
                    Constants.Rooms.Lounge
                }
            },
            {
                Constants.Rooms.GardenShed, new List<string>
                {
                    Constants.Rooms.Stairs
                }
            },
            {
                Constants.Rooms.Lounge, new List<string>
                {
                    Constants.Rooms.Garden,
                    Constants.Rooms.Outside
                }
            },
            {
                Constants.Rooms.Outside, new List<string>
                {
                    Constants.Rooms.Lounge
                }
            },
            {
                Constants.Rooms.Stairs, new List<string>
                {
                    Constants.Rooms.Garden,
                    Constants.Rooms.GardenShed
                }
            },
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
                    throw new ArgumentNullException($"Unable to find room named {roomName}. ");
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
