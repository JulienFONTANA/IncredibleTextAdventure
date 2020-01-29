using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.ComputerRoomItems
{
    public class EmptyDesk : Item, IComputerRoomItem
    {
        public EmptyDesk()
        {
            Name = Constants.Items.EmptyDesk;
            Description = "";
        }
    }
}
