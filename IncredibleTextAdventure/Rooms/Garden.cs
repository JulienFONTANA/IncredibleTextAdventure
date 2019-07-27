using IncredibleTextAdventure.Directives;
using IncredibleTextAdventure.Items;
using System.Collections.Generic;
using IncredibleTextAdventure.Directives.Garden;
using IncredibleTextAdventure.Items.GardenItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Garden : Room, IRoom
    {
        public Garden(IGardenDirective[] specialGardenDirective)
        {
            Name = "Garden";
            FirstDescription = @"You enter a magnificent [garden]. Tall trees cast their shadow on you, allowing you " 
                               +"to easily get used to the sun light. [Flowers] are blooming along the walls. In the " 
                               +"center of this garden is a [fountain], but alas no water in it. How come such a garden "
                               +"exists without water ?";
            Description = "A magnificent [garden], with [flowers] everywhere. In the center is a waterless [fountain].";
            IsAccessible = true;

            LinkedRooms = new List<string> { "Corridor" };

            ItemsInRoom = new List<IItem>
            {
                new Flowers(),
                new Fountain()
            };

            SpecialDirectives = specialGardenDirective;
        }
    }
}
