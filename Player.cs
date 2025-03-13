using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {

        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        
        public void PickUpItem(Room currentRoom) // Adds the current rooms item to inventory and removes it from the room
        {
            inventory.Add(currentRoom.GetItem());
            currentRoom.Item = "";
        }
        
        public void UseItem() 
        {
            inventory.Remove("Worn key");
        }
        
        public string InventoryContents() // Returns the player's current inventory
        {
            return string.Join(", ", inventory);
        }
        
        public int GetHealth() // Returns the player's current health
        {
            return Health;
        }
    }
}
