using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.GardenItems
{
    public class GoldenDoor : Item, IGardenItem
    {
        public GoldenDoor()
        {
            Name = Constants.Items.GoldenDoor;
            Description = "A richly ornamented [golden door]. Beside the keyhole, you can't find a way to open it.";
        }

        public override bool CanInteractWith(string other)
        {
            return other.EqualsIgnoreCase(Constants.Items.GoldenKey);
        }

        public override string InteractWith(IGameContext context)
        {
            Description = "A richly ornamented door. It opened effortlessly without sound on the [lounge].";
            const string result = "The doors [unlocks], and opens on a dark [corridor]...";
            return result;
        }

        public override string BlocksPathTo()
        {
            return Constants.Rooms.Lounge;
        }
    }
}