namespace IncredibleTextAdventure.Items.ServerRoomItems
{
    public class OpenTerminal : Item, IServerRoomItem
    {
        public OpenTerminal()
        {
            Name = LanguageConst.OpenTerminalObjectName;
            Description = LanguageConst.OpenTerminalObjectDesc;
        }
    }
}
