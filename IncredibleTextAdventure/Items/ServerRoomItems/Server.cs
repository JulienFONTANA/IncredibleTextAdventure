using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.ServerRoomItems
{
    public class Server : Item, IServerRoomItem
    {
        public Server()
        {
            Name = Constants.Items.Server;
            Description = "";
        }
    }
}
