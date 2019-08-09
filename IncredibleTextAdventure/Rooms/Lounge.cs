using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.LoungeItems;
using System.Collections.Generic;

namespace IncredibleTextAdventure.Rooms
{
    public class Lounge : Room, IRoom
    {
        public Lounge(IEnumerable<ILoungeItem> itemsInRoom)
        {
            Name = Constants.Rooms.Lounge;
            FirstDescription = "A cozy [lounge]. Dim light from the [garden] give the room a unique, out-of-time " +
                               "atmosphere. The walls are filled with [bookshelves], some fire crackles in a [chimney]... " +
                               "Here and there, huge oil [paintings] give the room a sad vibe. On the other side of the wall, " +
                               "a marble [altar] suddenly draws all of your attention. What is this place ? ";
            ItemsInRoom = new List<IItem>(itemsInRoom);
        }

        // TODO - update Lounge description
        //public override void UpdateDescription()
        //{
        //    Description = "A cozy [lounge]. Dim light from the [garden] give the room a unique, out-of-time " +
        //                  "atmosphere. The walls are filled with [bookshelves], some fire crackles in a [chimney]... " +
        //                  "Here and there, huge oil [paintings] give the room a sad vibe. On the other side of the wall, " +
        //                  "a marble [altar] suddenly draws all of your attention. What is this place ? ";
        //}
    }
}