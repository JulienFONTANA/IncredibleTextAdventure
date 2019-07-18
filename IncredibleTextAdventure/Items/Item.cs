namespace IncredibleTextAdventure.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
