using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Directives.Garden;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.GardenItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Garden : Room, IRoom
    {
        public Garden(IEnumerable<IGardenItem> itemsInRoom,
            IGardenDirective[] specialGardenDirective)
        {
            Name = Constants.Rooms.Garden;
            FirstDescription = "You exit the [corridor] and enter a magnificent [garden]. Tall trees cast their shadow on you, allowing you " 
                               +"to easily get used to the sun light. Strange [flowers] are blooming along the walls. In the " 
                               +"center of this garden is a [fountain], but alas no water in it. How come such a garden "
                               +"exists without water ? On your left are [stairs] seems up go to a room that overlooks the garden";

            Description = "A magnificent [garden], with [flowers] everywhere. In the center is a waterless [fountain]. " 
                          +"A pathway leads back to the [corridor], and on yout left [stairs] goes to an overlooking room.";
            IsRoomAccessible = true;

            ItemsInRoom = new List<IItem>(itemsInRoom);
            SpecialDirectives = specialGardenDirective;
        }
    }
}
