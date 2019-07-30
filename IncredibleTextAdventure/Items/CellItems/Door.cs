using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.CellItems
{
    public class Door : Item, ICellItem
    {
        public Door()
        {
            Name = Constants.Items.Door;
            Description = "It looks like a cell [door]. Through a small openning, you can see a dark [corridor].";
        }

        public override bool CanInteractWith(string other)
        {
            return other.EqualsIgnoreCase(Constants.Items.Key);
        }

        public override string InteractWith(IGameContext context)
        {
            Description = "An open cell door, which opens on a [corridor]. Doesn't looks that heavy now...";
            const string result = "The doors [unlocks], and opens on a dark [corridor]...";
            return result;
        }

        public override string BlocksPathTo()
        {
            return Constants.Rooms.Corridor;
        }
    }
}
