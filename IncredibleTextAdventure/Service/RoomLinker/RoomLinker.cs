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
                Constants.Rooms.OpenSpace, new List<string>
                {
                    Constants.Rooms.DeskOne,
                    Constants.Rooms.DeskTwo,
                    Constants.Rooms.DeskThree,
                    Constants.Rooms.DeskFour,
                    Constants.Rooms.ServerRoom,
                    Constants.Rooms.RestingRoom
                }
            },
            {
                Constants.Rooms.DeskOne, new List<string>
                {
                    Constants.Rooms.OpenSpace,
                    Constants.Rooms.DeskTwo,
                    Constants.Rooms.DeskThree,
                    Constants.Rooms.DeskFour
                }
            },
            {
                Constants.Rooms.DeskTwo, new List<string>
                {
                    Constants.Rooms.OpenSpace,
                    Constants.Rooms.DeskOne,
                    Constants.Rooms.DeskThree,
                    Constants.Rooms.DeskFour
                }
            },
            {
                Constants.Rooms.DeskThree, new List<string>
                {
                    Constants.Rooms.OpenSpace,
                    Constants.Rooms.DeskOne,
                    Constants.Rooms.DeskTwo,
                    Constants.Rooms.DeskFour
                }
            },
            {
                Constants.Rooms.DeskFour, new List<string>
                {
                    Constants.Rooms.OpenSpace,
                    Constants.Rooms.DeskOne,
                    Constants.Rooms.DeskTwo,
                    Constants.Rooms.DeskThree,
                    Constants.Rooms.DeskFour
                }
            },
            {
                Constants.Rooms.RestingRoom, new List<string>
                {
                    Constants.Rooms.OpenSpace
                }
            },
            {
                Constants.Rooms.ServerRoom, new List<string>
                {
                    Constants.Rooms.ComputerRoom,
                    Constants.Rooms.OpenSpace
                }
            },

            {
                Constants.Rooms.ComputerRoom, new List<string>
                {
                    Constants.Rooms.ServerRoom
                }
            }
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
