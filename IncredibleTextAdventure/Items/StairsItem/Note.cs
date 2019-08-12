using IncredibleTextAdventure.Constant;

namespace IncredibleTextAdventure.Items.StairsItem
{
    public class Note : Item, IStairsItem
    {
        public Note()
        {
            Name = Constants.Items.Note;
            Description = "A hand-written [note] in coal on a thick piece of paper. It is hard to understand, "
                          + "but you manage to read : 'Watch out for hidden places, with a new eye and a [new light], " +
                          "to find the [basement]. Secrets are to be found by one who can see in the dark. Inside is an immense treasure !'. " +
                          "Some words are wiped off. ";
            CanBePickedUp = true;
            IsVisible = false;
        }
    }
}
