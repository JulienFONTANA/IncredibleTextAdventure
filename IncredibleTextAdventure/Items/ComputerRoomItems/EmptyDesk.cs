namespace IncredibleTextAdventure.Items.ComputerRoomItems
{
    public class EmptyDesk : Item, IComputerRoomItem
    {
        public EmptyDesk()
        {
            Name = LanguageConst.EmptyDeskObjectName;
            Description = LanguageConst.EmptyDeskObjectDesc;
        }
    }
}
