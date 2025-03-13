namespace DungeonExplorer
{
    public class Room
    {

        private string Description;
        public string Item;
        public int DoorLocked;

        public Room(string Description, string Item, int DoorLocked)
        {
            this.Description = Description;
            this.Item = Item;
            this.DoorLocked = DoorLocked;
        }

        public string GetDescription() // Returns the rooms description
        {
            return Description;
        }
        
        public string GetItem() // Returns the rooms item
        {
            return Item;
        }
        
        public int CheckDoorLocked() 
        {
            return DoorLocked;
        }
    }
}
