using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.StairsItem;

namespace IncredibleTextAdventure.Rooms
{
    public class Stairs : Room, IRoom
    {
        public Stairs(IEnumerable<IStairsItem> itemsInRoom)
        {
            Name = Constants.Rooms.Stairs;
            FirstDescription = "A long, narrow and steep flight of [stairs], lit by small windows, led up to a [garden shed]. " 
                               +"Each step, while well maintained, start to be smooth and slippery, as if well used. " 
                               +"As you climb up, you come across a marble [bust], but can't say from whom. " 
                               +"Climbing is made easy by a small wind, comming from the Garden";
            Description = "[Stairs], from the [garden] to the [garden shed]";
            IsAccessible = true;
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        public override void UpdateDescription()
        {
            Description = "[Stairs], from the [garden] to the [garden shed]"
                          + (IsItemInRoom(Constants.Items.Bust) ? "A marble [bust] greets you half-way from the top." : string.Empty);
        }
    }
}
