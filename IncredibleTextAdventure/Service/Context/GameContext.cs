using System.Collections.Generic;
using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Rooms;
using IncredibleTextAdventure.Service.RoomStateManager;
using IncredibleTextAdventure.Service.SpecialEventManager;
using System.Linq;

namespace IncredibleTextAdventure.Service.Context
{
    public class GameContext : IGameContext
    {
        private readonly IPlayer _player;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConsoleReader _consoleReader;
        private readonly IDirective[] _directives;
        private readonly IRoom[] _rooms;
        private readonly ISpecialEventManager _specialEventManager;
        private readonly IRoomStateManager _roomStateManager;

        private bool _isGameOver;

        public GameContext(IPlayer player,
            IConsoleWriter consoleWriter,
            IConsoleReader consoleReader,
            IDirective[] directives,
            IRoom[] rooms,
            ISpecialEventManager specialEventManager,
            IRoomStateManager roomStateManager)
        {
            _player = player;
            _consoleWriter = consoleWriter;
            _consoleReader = consoleReader;
            _directives = directives;
            _rooms = rooms;
            _specialEventManager = specialEventManager;
            _roomStateManager = roomStateManager;

            _isGameOver = false;
        }

        public bool Command(string cmd)
        {
            if (cmd.EqualsIgnoreCase("Exit") || cmd.EqualsIgnoreCase("Quit"))
            {
                CheckExitGame();
            }

            var foundAction = false;
            var specialDirectives = GetCurrentRoom().GetSpecialDirectives();
            if (specialDirectives.Any())
            {
                foundAction = TryActionFromDirectiveList(cmd, specialDirectives);
            }
            if (!foundAction)
            {
                foundAction = TryActionFromDirectiveList(cmd, _directives);
            }
            if (!foundAction)
            {
                _consoleWriter.WriteToConsole("You can't do that... ");
            }
            if (_isGameOver)
            {
                CheckScore();
            }

            return _isGameOver;
        }

        private bool TryActionFromDirectiveList(string cmd, IEnumerable<IDirective> specialDirectives)
        {
            foreach (var action in specialDirectives)
            {
                if (action.CanApply(cmd))
                {
                    action.TryApply(cmd, this);
                    return true;
                }
            }

            return false;
        }

        public void EndGame()
        {
            _isGameOver = true;
        }

        public IRoom GetCurrentRoom()
        {
            return _rooms.FirstOrDefault(r => r.Equals(GetPlayer().GetPlayerLocation()));
        }

        public IRoom GetRoom(string room)
        {
            return _rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(room));
        }

        public IRoom GetRoom(IRoom room)
        {
            return _rooms.FirstOrDefault(r => r.Equals(room));
        }

        public IPlayer GetPlayer()
        {
            return _player;
        }

        public void TriggerSpecialEvent(string eventName)
        {
            _specialEventManager.SpecialEvent(eventName, _player);
        }

        public void OpenRoom(IRoom room)
        {
            _roomStateManager.OpenRoom(room);
        }

        // TODO - VOVF
        private void CheckExitGame()
        {
            _consoleWriter.WriteToConsole("Are you sure you want to exit the game ? [Exit / Quit] is not a valid in game command. "
                                        + "If you want to exit the game, press 'Y'");
            var answer = _consoleReader.ReadLineFromConsole();
            if (answer.Trim().EqualsIgnoreCase("Y"))
            {
                _isGameOver = true;
            }
        }

        // TODO - VOVF
        private void CheckScore()
        {
            //_consoleWriter.WriteToConsole("You exit the house through the painting and come back to the material world. " +
            //                              "You need some time to understand what happened... ");

            //if (!ReferenceEquals(_player.GetItemFromInventory(Constants.Items.RubyRing), null))
            //{
            //    _consoleWriter.WriteToConsole("You check your pocket, and the [ruby ring] is here ! It must have been " +
            //                                  "a farewell gift from emily. ");
            //    _consoleWriter.WriteToConsole("[Thanks for playing !] You discovered everything inside the wizard's house ! ");
            //}
            //else
            //{
            //    _consoleWriter.WriteToConsole("You feel somewhat lost. You must have missed something. There is no other explanation... ");
            //    _consoleWriter.WriteToConsole("[Thanks for playing !] You might want to come back, as you forgot some secrets during " +
            //                                  "your adventure. Maybe use the [lantern] to lighten you path in dark places next time ?");
            //}

            _isGameOver = true;
        }
    }
}
