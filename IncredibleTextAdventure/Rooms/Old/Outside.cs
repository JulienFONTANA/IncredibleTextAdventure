using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Rooms
{
    public class Outside : Room, IRoom
    {
        public Outside()
        {
            Name = Constants.Rooms.Outside;
            FirstDescription = "You're outside ! ";
            IsRoomAccessible = false;
        }
    }
}
