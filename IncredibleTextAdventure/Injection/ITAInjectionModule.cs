using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Directives.GodMode;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items.ComputerRoomItems;
using IncredibleTextAdventure.Items.Desk1Items;
using IncredibleTextAdventure.Items.Desk2Items;
using IncredibleTextAdventure.Items.Desk3Items;
using IncredibleTextAdventure.Items.Desk4Items;
using IncredibleTextAdventure.Items.RestingRoomItems;
using IncredibleTextAdventure.Items.ServerRoomItems;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;
using IncredibleTextAdventure.Service.LanguageModule;
using IncredibleTextAdventure.Service.RoomLinker;
using IncredibleTextAdventure.Service.RoomStateManager;
using IncredibleTextAdventure.Service.SpecialEventManager;
using Ninject.Modules;

namespace IncredibleTextAdventure.Injection
{
    public class ItaInjectionModule : NinjectModule
    {
        private readonly char _language;
        public ItaInjectionModule(char language)
        {
            _language = language;
        }

        public override void Load()
        {
            BindService(_language);
            BindConsole();
            BindPlayer();
            BindDirectives();
            BindRooms();
            BindObjects();
        }

        private void BindObjects()
        {
            Bind<IComputerRoomItem>().To<EmptyDesk>();
            Bind<IComputerRoomItem>().To<NotesAboutAUsbKey>();
            Bind<IComputerRoomItem>().To<WeirdLookingWorkingStation>();

            Bind<IDesk1Item>().To<FlowerInPot>();
            Bind<IDesk1Item>().To<RubiksCube>();

            Bind<IDesk2Item>().To<ConcertPhoto>();
            Bind<IDesk2Item>().To<PileOfStickyNotes>();

            Bind<IDesk3Item>().To<ChildsDrawing>();
            Bind<IDesk3Item>().To<DeskFan>();
            Bind<IDesk3Item>().To<PenHolder>();

            Bind<IDesk4Item>().To<CoffeeMachineCoins>();
            Bind<IDesk4Item>().To<TravelBug>();

            Bind<IRestingRoomItem>().To<CoffeeMachine>();
            Bind<IRestingRoomItem>().To<ComfyChairs>();

            Bind<IServerRoomItem>().To<OpenTerminal>();
            Bind<IServerRoomItem>().To<Server>();
        }

        private void BindRooms()
        {
            Bind<IRoom>().To<ComputerRoom>().InSingletonScope();
            Bind<IRoom>().To<Desk1>().InSingletonScope();
            Bind<IRoom>().To<Desk2>().InSingletonScope();
            Bind<IRoom>().To<Desk3>().InSingletonScope();
            Bind<IRoom>().To<Desk4>().InSingletonScope();
            Bind<IRoom>().To<OpenSpace>().InSingletonScope();
            Bind<IRoom>().To<RestingRoom>().InSingletonScope();
            Bind<IRoom>().To<ServerRoom>().InSingletonScope();
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

        private void BindService(char language)
        {
            Bind<IItaService>().To<ItaService>();
            Bind<IGameContext>().To<GameContext>();
            Bind<IRoomLinker>().To<RoomLinker>();
            Bind<IRoomStateManager>().To<RoomStateManager>();
            Bind<ISpecialEventManager>().To<SpecialEventManager>();

            if (_language == 'e')
            {
                Bind<ILanguageConst>().To<LanguageConstEn>();
            }
            // TODO - rebind Fr language module
            //else if (language == 'f')
            //{
            //    Bind<ILanguageConst>().To<LanguageConstFr>();
            //}
        }

        private void BindConsole()
        {
            Bind<IConsoleReader>().To<ConsoleReader>();
            Bind<IConsoleWriter>().To<ConsoleWriter>();
        }
    }
}
