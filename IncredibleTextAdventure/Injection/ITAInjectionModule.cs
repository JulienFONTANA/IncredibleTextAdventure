using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Directives.Bar;
using IncredibleTextAdventure.Directives.Cell;
using IncredibleTextAdventure.Directives.Corridor;
using IncredibleTextAdventure.Directives.Garden;
using IncredibleTextAdventure.Directives.GodMode;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.BarItems;
using IncredibleTextAdventure.Items.BasementItems;
using IncredibleTextAdventure.Items.CellItems;
using IncredibleTextAdventure.Items.CorridorItems;
using IncredibleTextAdventure.Items.GardenItems;
using IncredibleTextAdventure.Items.GardenShedItems;
using IncredibleTextAdventure.Items.LoungeItems;
using IncredibleTextAdventure.Items.OtherItems;
using IncredibleTextAdventure.Items.StairsItem;
using IncredibleTextAdventure.Rooms;
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
            Bind<IBarItem>().To<AlcoholDispenser>();
            Bind<IBarItem>().To<Bottle>();
            Bind<IBarItem>().To<EmptyBottle>();
            Bind<IBarItem>().To<LeatherChairs>();
            Bind<IBarItem>().To<GoldenKey>();

            Bind<IBasementItem>().To<RubyRing>();
            Bind<IBasementItem>().To<WeirdTools>();

            Bind<ICellItem>().To<Door>();
            Bind<ICellItem>().To<Key>();
            Bind<ICellItem>().To<Table>();
            Bind<ICellItem>().To<BrokenTable>();
            Bind<ICellItem>().To<TableLeg>();

            Bind<ICorridorItem>().To<Signs>();

            Bind<IGardenItem>().To<Flowers>();
            Bind<IGardenItem>().To<Fountain>();
            Bind<IGardenItem>().To<GoldenDoor>();
            Bind<IGardenItem>().To<WaterlessFountain>();

            Bind<IGardenShedItem>().To<ActivatedMechanism>();
            Bind<IGardenShedItem>().To<LanternWithoutAlcohol>();
            Bind<IGardenShedItem>().To<Mechanism>();
            Bind<IGardenShedItem>().To<Windows>();

            Bind<ILoungeItem>().To<Altar>();
            Bind<ILoungeItem>().To<Bookshelves>();
            Bind<ILoungeItem>().To<Chimney>();
            Bind<ILoungeItem>().To<Paintings>();

            Bind<IStairsItem>().To<Bust>();
            Bind<IStairsItem>().To<Note>();

            Bind<IItem>().To<Lantern>();
            Bind<IItem>().To<Vase>();
            Bind<IItem>().To<Bouquet>();
        }

        private void BindRooms()
        {
            Bind<IRoom>().To<Bar>().InSingletonScope();
            Bind<IRoom>().To<Basement>().InSingletonScope();
            Bind<IRoom>().To<Cell>().InSingletonScope();
            Bind<IRoom>().To<Corridor>().InSingletonScope();
            Bind<IRoom>().To<Garden>().InSingletonScope();
            Bind<IRoom>().To<GardenShed>().InSingletonScope();
            Bind<IRoom>().To<Lounge>().InSingletonScope();
            Bind<IRoom>().To<Stairs>().InSingletonScope();
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
            Bind<IDirective>().To<InfoDirective>();
            Bind<IDirective>().To<OpenDirective>();

            Bind<IBarDirective>().To<EmptyBottleDirective>();
            Bind<ICellDirective>().To<BreakDirective>();
            Bind<ICorridorDirective>().To<UseLanternDirective>();
            Bind<IGardenDirective>().To<DrinkDirective>();
            Bind<IGardenDirective>().To<FillBottleDirective>();

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
