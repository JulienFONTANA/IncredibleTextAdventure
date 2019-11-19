namespace IncredibleTextAdventure.Items.ServerRoomItems
{
    public class Server : Item, IServerRoomItem
    {
        public Server()
        {
            Name = LanguageConst.ServerObjectName;
            Description = LanguageConst.ServerObjectDesc;
        }
    }
}
