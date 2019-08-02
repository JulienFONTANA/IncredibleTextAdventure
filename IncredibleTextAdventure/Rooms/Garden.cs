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
                               +"center of this garden is a [waterless fountain]. How come such a garden "
                               +"exists without water ? On your left are [stairs] seems up go to a room that overlooks the garden. "
                               +"In front of you, a [golden door] blocks the way.";

            IsRoomAccessible = true;

            ItemsInRoom = new List<IItem>(itemsInRoom);
            SpecialDirectives = specialGardenDirective;
        }

        public override void UpdateDescription()
        {
            Description = "A magnificent [garden], with [flowers] everywhere. " +
                          (IsItemInRoom(Constants.Items.WaterlessFountain) ? 
                              "In the center is a [waterless fountain]. " :
                              "The water from the [fountain] is clear and cold. ") + 
                          (IsLinkedRoomAccessible(Constants.Rooms.Bar) ? 
                              "You never could have noticed the path to the [bar] on your right, which opened as you brought back " +
                              "water. The door must have been made of the same things that made the walls ! " 
                              : string.Empty) +
                          (IsLinkedRoomAccessible(Constants.Rooms.Lounge) ?
                              "The [golden door] is now unlocked, opening the luxurious [lounge]."
                              : "In front of you, a [golden door] blocks the way.") +
                          "A pathway leads back to the [corridor], and on your left [stairs] goes to an overlooking room.";
        }
    }
}
