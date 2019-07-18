using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Directives.Action;
using IncredibleTextAdventure.Directives.Move;
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
            BindActionDirectives();
            BindMoveDirectives();
        }

        private void BindActionDirectives()
        {
            Bind<IDirective>().To<HelpDirective>();
            Bind<IDirective>().To<LookDirective>();
        }


        private void BindMoveDirectives()
        {
            Bind<IDirective>().To<MoveNorthDirective>();
            Bind<IDirective>().To<MoveSouthDirective>();
            Bind<IDirective>().To<MoveEastDirective>();
            Bind<IDirective>().To<MoveWestDirective>();
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
