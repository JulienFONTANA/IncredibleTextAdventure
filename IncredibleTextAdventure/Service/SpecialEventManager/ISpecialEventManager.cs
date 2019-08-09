using IncredibleTextAdventure.Characters;

namespace IncredibleTextAdventure.Service.SpecialEventManager
{
    public interface ISpecialEventManager
    {
        void SpecialEvent(string eventName, IPlayer player);
    }
}