namespace IncredibleTextAdventure.Items.Desk1Items
{
    public class RubiksCube : Item, IDesk1Item
    {
        public RubiksCube()
        {
            Name = LanguageConst.RubiksCubeObjectName;
            Description = LanguageConst.RubiksCubeObjectDesc;
        }

        //public override bool CanInteractWith(string other)
        //{
        //    return other.EqualsIgnoreCase(Constants.Items.Key);
        //}

        //public override string InteractWith(IGameContext context)
        //{
        //    Description = "An open cell door, which opens on a [corridor]. Doesn't looks that heavy now... ";
        //    const string result = "The door [unlocks], and opens on a dark [corridor]... ";
        //    return result;
        //}

        //public override string BlocksPathTo()
        //{
        //    return Constants.Rooms.Corridor;
        //}
    }
}
