namespace DungeonExplorer
{
    public class Room
    {
        private string Description;
        public string Item;
        
        public Room(string Description, string Item)
        {
            this.Description = Description;
            this.Item = Item;
        }

        public string GetDescription() // Returns the rooms description
        {
            return Description;
        }
    
        public string GetItem() // Returns the rooms item
        {
            return Item;
        }
    }
}
