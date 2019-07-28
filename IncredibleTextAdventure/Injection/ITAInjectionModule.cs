using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Directives.Garden;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items.CellItems;
using IncredibleTextAdventure.Items.GardenItems;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.RoomLinker;
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
            Bind<ICellItem>().To<Door>();
            Bind<ICellItem>().To<Key>();
            Bind<ICellItem>().To<Table>();

            Bind<IGardenItem>().To<Flowers>();
            Bind<IGardenItem>().To<Fountain>();
        }

        private void BindRooms()
        {
            Bind<IRoom>().To<Cell>().InSingletonScope();
            Bind<IRoom>().To<Corridor>().InSingletonScope();
            Bind<IRoom>().To<Garden>().InSingletonScope();
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
            Bind<IRoomLinker>().To<RoomLinker>();
        }

        private void BindConsole()
        {
            Bind<IConsoleReader>().To<ConsoleReader>();
            Bind<IConsoleWriter>().To<ConsoleWriter>();
        }
    }
}
