using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Directives.Garden;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;
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
        }

        private void BindRooms()
        {
            Bind<IRoom>().To<Cell>();
            Bind<IRoom>().To<Corridor>();
            Bind<IRoom>().To<Garden>();
        }

        private void BindDirectives()
        {
            Bind<IDirective>().To<LookDirective>();
            Bind<IDirective>().To<MoveDirective>();
            Bind<IDirective>().To<HelpDirective>();
            Bind<IDirective>().To<PickDirective>();
            Bind<IDirective>().To<InventoryDirective>();
            Bind<IDirective>().To<UseDirective>();
            Bind<IDirective>().To<WhereDirective>();

            Bind<IGardenDirective>().To<DrinkDirective>();
        }

        private void BindPlayer()
        {
            Bind<IPlayer>().To<Player>();
        }

        private void BindService()
        {
            Bind<IItaService>().To<ItaService>();
            Bind<IGameContext>().To<GameContext>();
        }

        private void BindConsole()
        {
            Bind<IConsoleReader>().To<ConsoleReader>();
            Bind<IConsoleWriter>().To<ConsoleWriter>();
        }
    }
}
