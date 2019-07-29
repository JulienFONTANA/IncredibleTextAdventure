using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Rooms
{
    public class Corridor : Room, IRoom
    {
        public Corridor()
        {
            Name = Constants.Rooms.Corridor;
            FirstDescription = "A dark and humid corridor. At the very end, you see light, and what looks like " 
                             + "a [garden]. Behind you is the [cell] you just left.";
            Description = "The link between your [cell] and the [garden].";
        }
    }
}
