using System.Collections.Generic;
using System.Linq;
using IncredibleTextAdventure.Characters;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items.BarItems;
using IncredibleTextAdventure.Rooms;

namespace IncredibleTextAdventure.Service.SpecialEventManager
{
    public class SpecialEventManager : ISpecialEventManager
    {
        private readonly List<IRoom> _rooms;

        public SpecialEventManager(IEnumerable<IRoom> rooms)
        {
            _rooms = rooms.ToList();
        }

        public void SpecialEvent(string eventName, IPlayer player)
        {
            switch (eventName)
            {
                case Constants.Events.BreakTable:
                    BreakTable();
                    break;
                case Constants.Events.RunningWater:
                    RunningWater();
                    break;
                case Constants.Events.EmptyBottle:
                    EmptyBottle();
                    break;
                default:
                    break;
            }
        }

        /*
         * When the table is broken in the Cell, two "new" items take its place,
         * the broken table and the table leg.
         */
        private void BreakTable()
        {
            var room = _rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(Constants.Rooms.Cell));
            if (!ReferenceEquals(room, null))
            {
                room.GetItem(Constants.Items.Table).SetItemVisibility(false);
                room.GetItem(Constants.Items.TableLeg).SetItemVisibility(true);
                room.GetItem(Constants.Items.BrokenTable).SetItemVisibility(true);
            }
        }

        /*
         * When the mechanism is activated in the Garden Shed,
         * the waterless fountain is replaced by the fountain
         */
        private void RunningWater()
        {
            var room = _rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(Constants.Rooms.Garden));
            if (!ReferenceEquals(room, null))
            {
                room.GetItem(Constants.Items.WaterlessFountain).SetItemVisibility(false);
                room.GetItem(Constants.Items.Fountain).SetItemVisibility(true);
            }
        }

        /*
         * When the bottle is emptied in the bar, the bottle becomes
         * empty and the golden key falls out.
         */
        public void EmptyBottle()
        {
            var room = _rooms.FirstOrDefault(r => r.Name.EqualsIgnoreCase(Constants.Rooms.Bar));
            if (!ReferenceEquals(room, null))
            {
                room.GetItem(Constants.Items.Bottle).SetItemVisibility(false);
                room.GetItem(Constants.Items.EmptyBottle).SetItemVisibility(true);
                room.GetItem(Constants.Items.GoldenKey).SetItemVisibility(true);
            }
        }
    }
}
