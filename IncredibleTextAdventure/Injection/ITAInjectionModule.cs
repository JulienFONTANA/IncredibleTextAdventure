using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;
using Ninject.Modules;

namespace IncredibleTextAdventure.Injection
{
    public class ITAInjectionModule : NinjectModule
    {
        public override void Load()
        {
            BindService();
            BindConsole();
            BindPlayer();
            BindDirectives();
        }

        private void BindDirectives()
        {
            Bind<IDirective>().To<LookDirective>();
            Bind<IDirective>().To<MoveDirective>();
            Bind<IDirective>().To<HelpDirective>();
        }

        private void BindPlayer()
        {
            Bind<IPlayer>().To<Player>();
        }

        private void BindService()
        {
            Bind<IITAService>().To<ITAService>();
            Bind<IGameContext>().To<GameContext>();
        }

        private void BindConsole()
        {
            Bind<IConsoleReader>().To<ConsoleReader>();
            Bind<IConsoleWriter>().To<ConsoleWriter>();
        }
    }
}
