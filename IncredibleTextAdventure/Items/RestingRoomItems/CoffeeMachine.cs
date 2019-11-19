namespace IncredibleTextAdventure.Items.RestingRoomItems
{
    public class CoffeeMachine : Item, IRestingRoomItem
    {
        public CoffeeMachine()
        {
            Name = LanguageConst.CoffeeMachineObjectName;
            Description = LanguageConst.CoffeeMachineObjectDesc;
        }
    }
}
