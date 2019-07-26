using IncredibleTextAdventure.Service.Context;

namespace IncredibleTextAdventure.Items
{
    public class Fountain : Item, IItem
    {
        public Fountain()
        {
            Name = "Fountain";
            Description = "A huge fountain, depicting gods and demons dancing together... "
                        + "The traces of running water have left marks, but asof now, the whole monument is dry.";
            CanBePickedUp = false;
        }

        public override bool CanInteractWith(string other)
        {
            return false;
        }

        public override void InteractWith(IGameContext context)
        {
            return;
        }
    }
}
