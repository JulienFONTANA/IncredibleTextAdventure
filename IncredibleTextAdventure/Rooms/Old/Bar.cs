using System.Collections.Generic;
using IncredibleTextAdventure.Constant;
using IncredibleTextAdventure.Directives.Bar;
using IncredibleTextAdventure.Items;
using IncredibleTextAdventure.Items.BarItems;

namespace IncredibleTextAdventure.Rooms
{
    public class Bar : Room, IRoom
    {
        public Bar(IEnumerable<IBarItem> itemsInRoom,
            IBarDirective[] specialBarDirectives)
        {
            Name = Constants.Rooms.Bar;
            FirstDescription = "As you step into the room, you're surprised by its ambiance. " +
                               "What looks like electric lightning still buzzes over a dusty [bar]. " +
                               "Behind the counter is a lone [bottle] and glasses. In a corner, " +
                               "some comfy looking [leather chairs] still seem awaiting the next customer. " +
                               "On one end of the bar is an [alcohol dispenser]. Through the open door, " +
                               "you can still smell the [garden] and hear the water drizzle. ";

            ItemsInRoom = new List<IItem>(itemsInRoom);
            SpecialDirectives = specialBarDirectives;
        }

        public override void UpdateDescription()
        {
            Description = "The [bar] seems to await someone still. The [garden] is behind you. " +
                          (IsItemInRoom(Constants.Items.Bottle) ? 
                              "Behind the counter is a lone [bottle] and glasses. " :
                              "Behind the counter is a clean spot where the [bottle] used to be. ") +
                          (IsItemInRoom(Constants.Items.EmptyBottle) ? "The [empty bottle] is on the bar. " : string.Empty ) +
                          (IsItemInRoom(Constants.Items.GoldenKey) ? 
                              "A small, shining [golden key] that came out of the bottle felt on the floor. " : string.Empty ) +
                          "In a corner are some [leather chairs]. " +
                          "On one end of the bar is an [alcohol dispenser]. ";
        }
    }
}