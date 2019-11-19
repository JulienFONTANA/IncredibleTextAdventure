using IncredibleTextAdventure.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Service.LanguageModule;

namespace IncredibleTextAdventure.Service.RoomLinker
{
    public class RoomLinker : IRoomLinker
    {
        private readonly ILanguageConst _languageConst;
        private readonly List<IRoom> _rooms;
        private Dictionary<string, List<string>> _linkedRoomList;

        public RoomLinker(IEnumerable<IRoom> rooms, ILanguageConst languageConst)
        {
            _languageConst = languageConst;
            _rooms = rooms.ToList();
        }

        public void InitRoomConnection()
        {
            InitRoomLink();
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

        private void InitRoomLink()
        {
            _linkedRoomList = new Dictionary<string, List<string>>
            {
                {
                    _languageConst.OpenSpaceName, new List<string>
                    {
                        _languageConst.DeskOneName,
                        _languageConst.DeskTwoName,
                        _languageConst.DeskThreeName,
                        _languageConst.DeskFourName,
                        _languageConst.ServerRoomName,
                        _languageConst.RestingRoomName
                    }
                },
                {
                    _languageConst.DeskOneName, new List<string>
                    {
                        _languageConst.OpenSpaceName,
                        _languageConst.DeskTwoName,
                        _languageConst.DeskThreeName,
                        _languageConst.DeskFourName
                    }
                },
                {
                    _languageConst.DeskTwoName, new List<string>
                    {
                        _languageConst.OpenSpaceName,
                        _languageConst.DeskOneName,
                        _languageConst.DeskThreeName,
                        _languageConst.DeskFourName
                    }
                },
                {
                    _languageConst.DeskThreeName, new List<string>
                    {
                        _languageConst.OpenSpaceName,
                        _languageConst.DeskOneName,
                        _languageConst.DeskTwoName,
                        _languageConst.DeskFourName
                    }
                },
                {
                    _languageConst.DeskFourName, new List<string>
                    {
                        _languageConst.OpenSpaceName,
                        _languageConst.DeskOneName,
                        _languageConst.DeskTwoName,
                        _languageConst.DeskThreeName,
                        _languageConst.DeskFourName
                    }
                },
                {
                    _languageConst.RestingRoomName, new List<string>
                    {
                        _languageConst.OpenSpaceName
                    }
                },
                {
                    _languageConst.ServerRoomName, new List<string>
                    {
                        _languageConst.ComputerRoomName,
                        _languageConst.OpenSpaceName
                    }
                },

                {
                    _languageConst.ComputerRoomName, new List<string>
                    {
                        _languageConst.ServerRoomName
                    }
                }
            };
        }

    }
}
