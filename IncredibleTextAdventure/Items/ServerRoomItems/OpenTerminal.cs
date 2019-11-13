using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.ServerRoomItems
{
    public class OpenTerminal : Item, IServerRoomItem
    {
        public OpenTerminal()
        {
            Name = Constants.Items.OpenTerminal;
            Description = "";
        }
    }
}
