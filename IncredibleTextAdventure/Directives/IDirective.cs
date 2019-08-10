using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives
{
    public interface IDirective
    {
        bool CanApply(string cmd);
        void TryApply(string cmd, IGameContext context);
    }
}