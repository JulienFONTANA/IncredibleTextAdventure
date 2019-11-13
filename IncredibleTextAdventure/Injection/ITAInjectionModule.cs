using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Directives.GodMode;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.RoomLinker;
using IncredibleTextAdventure.Service.RoomStateManager;
using IncredibleTextAdventure.Service.SpecialEventManager;
using Ninject.Modules;

namespace IncredibleTextAdventure.Injection
{
    public class ItaInjectionModule : NinjectModule
    {
        public override void Load()
        {
            BindService();
            BindConsole();
            BindPlayer();
            BindDirectives();
            BindRooms();
            BindObjects();
        }

        private void BindObjects()
        {
            //Bind<IBarItem>().To<AlcoholDispenser>();
        }

        private void BindRooms()
        {
            //Bind<IRoom>().To<Bar>().InSingletonScope();
        }

        private void BindDirectives()
        {
            //Bind<IDirective>().To<LookDirective>();

            #if DEBUG
            BindGodMode();
            #endif
        }

        private void BindGodMode()
        {
            Bind<IDirective>().To<TeleportDirective>();
            Bind<IDirective>().To<GiveMeDirective>();
            Bind<IDirective>().To<FullInfoDirective>();
        }

        private void BindPlayer()
        {
            Bind<IPlayer>().To<Player>();
        }

        private void BindService()
        {
            Bind<IItaService>().To<ItaService>();
            Bind<IGameContext>().To<GameContext>();
            Bind<IRoomLinker>().To<RoomLinker>();
            Bind<IRoomStateManager>().To<RoomStateManager>();
            Bind<ISpecialEventManager>().To<SpecialEventManager>();
        }

        private void BindConsole()
        {
            Bind<IConsoleReader>().To<ConsoleReader>();
            Bind<IConsoleWriter>().To<ConsoleWriter>();
        }
    }
}
