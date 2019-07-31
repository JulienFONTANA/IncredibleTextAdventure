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
    public class HaveDirective : IDirective
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly List<IItem> _allItems;

        private const string CmdPattern = "^(have)";
        private const string FullPattern = "^(have)[ \t]?(?<capture>(.*))";

        public HaveDirective(IConsoleWriter consoleWriter,
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
            var match = Regex.Match(cmd, FullPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var capture = match.Groups["capture"].Value.Trim();

                if (!ReferenceEquals(context.GetPlayer().GetItemFromInventory(capture), null))
                {
                    _consoleWriter.WriteToConsole($"Object [{capture}] is already in the player's inventory");
                    return;
                }

                var objToPickUp = _allItems.FirstOrDefault(i => i.Name.EqualsIgnoreCase(capture));
                if (ReferenceEquals(objToPickUp, null))
                {
                    _consoleWriter.WriteToConsole($"Object {capture} not found in item list.");
                    return;
                }

                objToPickUp.SetItemVisibility(true);
                context.GetPlayer().AddToInventory(objToPickUp);
            }
        }
    }
}
