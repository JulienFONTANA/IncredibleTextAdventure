using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.RestingRoomItems
{
    public class CoffeeMachine : Item, IRestingRoomItem
    {
        public CoffeeMachine()
        {
            Name = Constants.Items.CoffeeMachine;
            Description = "";
        }
    }
}
