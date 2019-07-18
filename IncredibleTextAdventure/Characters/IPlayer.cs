namespace IncredibleTextAdventure.Characters
{
    public interface IPlayer
    {
        int xCoord { get; set; }
        int yCoord { get; set; }

        void Info();
    }
}