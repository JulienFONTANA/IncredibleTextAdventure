using IncredibleTextAdventure.Characters;

namespace IncredibleTextAdventure.Directives
{
    public interface IDirective
    {
        void Execute(IPlayer player);
        bool CanApply(string cmd);
    }
}