using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using IncredibleTextAdventure.ITAConsole;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.BarItems;
using IncredibleTextAdventure.Items.BasementItems;
using IncredibleTextAdventure.Items.CellItems;
using IncredibleTextAdventure.Items.CorridorItems;
using IncredibleTextAdventure.Items.GardenItems;
using IncredibleTextAdventure.Items.GardenShedItems;
using IncredibleTextAdventure.Items.LoungeItems;
using IncredibleTextAdventure.Items.StairsItem;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Directives.GodMode
{
    public class GiveMeDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly List<IItem> _allItems;

        private const string CmdPattern = "^(give me)";
        private const string FullPattern = "^(give me)[ \t]?(?<object>(.*))";
        private const string FullPatternExtended = "^(give me)[ \t]?(?<object>(.*))(in)[ \t]?(?<room>(.*))";

        public GiveMeDirective(IConsoleWriter consoleWriter,
            IEnumerable<IBarItem> barItems,
            IEnumerable<IBasementItem> basementItems,
            IEnumerable<ICellItem> cellItems,
            IEnumerable<ICorridorItem> corridorItems,
            IEnumerable<IGardenItem> gardenItems,
            IEnumerable<IGardenShedItem> gardenShedItems,
            IEnumerable<ILoungeItem> loungeItems,
            IEnumerable<IStairsItem> stairsItems)
        {
            _consoleWriter = consoleWriter;
            _allItems = new List<IItem>();

            _allItems.AddRange(barItems);
            _allItems.AddRange(basementItems);
            _allItems.AddRange(cellItems);
            _allItems.AddRange(corridorItems);
            _allItems.AddRange(gardenItems);
            _allItems.AddRange(gardenShedItems);
            _allItems.AddRange(loungeItems);
            _allItems.AddRange(stairsItems);
        }

        public bool CanApply(string cmd)
        {
            return Regex.IsMatch(cmd, CmdPattern, RegexOptions.IgnoreCase);
        }

        public void TryApply(string cmd, GameContext context)
        {
            Match match;
            if (Regex.IsMatch(cmd, FullPatternExtended, RegexOptions.IgnoreCase))
            {
                match = Regex.Match(cmd, FullPatternExtended, RegexOptions.IgnoreCase);
            }
            else if (Regex.IsMatch(cmd, FullPattern, RegexOptions.IgnoreCase))
            {
                match = Regex.Match(cmd, FullPattern, RegexOptions.IgnoreCase);
            }
            else
            {
                _consoleWriter.WriteToConsole($"Can't understand command {cmd}");
                return;
            }

            if (match.Success)
            {
                var objToGet = match.Groups["object"].Value.Trim();
                var roomItem = match.Groups["room"].Value.Trim();

                if (!ReferenceEquals(context.GetPlayer().GetItemFromInventory(objToGet), null))
                {
                    _consoleWriter.WriteToConsole($"Object [{objToGet}] is already in the player's inventory");
                    return;
                }

                IItem objToPickUp;
                if (string.IsNullOrEmpty(roomItem))
                {
                    objToPickUp = _allItems.FirstOrDefault(i => i.Name.EqualsIgnoreCase(objToGet));
                }
                else
                {
                    objToPickUp = context.GetRoom(roomItem).GetItem(objToGet);
                    if (ReferenceEquals(objToPickUp, null))
                    {
                        _consoleWriter.WriteToConsole($"Object [{objToGet}] doesn't belong in room [{roomItem}]. ");
                        return;
                    }
                }

                if (ReferenceEquals(objToPickUp, null))
                {
                    _consoleWriter.WriteToConsole($"Object [{objToGet}] not found in item list. ");
                    return;
                }

                if (!objToPickUp.CanBePickedUp)
                {
                    _consoleWriter.WriteToConsole($"Warning, object [{objToPickUp.Name}] can't be picked up by a normal player !!!");
                }
                if (!objToPickUp.IsItemVisible())
                {
                    _consoleWriter.WriteToConsole($"Warning, object [{objToPickUp.Name}] is not visible directly by the player !!!");
                }

                objToPickUp.SetItemVisibility(true);
                context.GetPlayer().AddToInventory(objToPickUp);
            }
        }
    }
}
