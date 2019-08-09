using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Service;
using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items.GardenShedItems
{
    public class Mechanism : Item, IGardenShedItem
    {
        public Mechanism()
        {
            Name = Constants.Items.Mechanism;
            Description = "A complex copper [mechanism]. While you don't really know what's it for, a glass opening " 
                        + "in one of the tubes shows water. Maybe this is the [fountain's] water supply ? " 
                        + "In any case, you quickly find out that the main [lever] is missing. ";
        }

        public override bool CanInteractWith(string other)
        {
            return other.EqualsIgnoreCase(Constants.Items.TableLeg);
        }

        public override string InteractWith(IGameContext context)
        {
            const string result = "The [mechanism] clicks, steams comes out of pipes, the whole machinery starts " +
                                  "to tremble, the sound become more and more deafening... And suddenly it stops. " +
                                  "All is left is the nice, relaxing sound of [running water] !";
            context.TriggerSpecialEvent(Constants.Events.RunningWater);
            return result;
        }

        public override string BlocksPathTo()
        {
            return Constants.Rooms.Bar;
        }
    }
}
