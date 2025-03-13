using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialized the game with one room and one player
            player = new Player("Alex", 30);
            Room room = new Room("You find yourself in an empty room", "Key");
            currentRoom = room;
        }
        
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                // Playing logic
                Console.WriteLine("Your choices are :");
                Console.WriteLine("- room description");
                Console.WriteLine("- check room for item");
                Console.WriteLine("- check health");
                Console.WriteLine("- check inventory");
                Console.WriteLine("");
                while (playing) 
                {
                    switch (Console.ReadLine())
                    {
                        case "room description": // Prints out the description of the current room
                            Console.WriteLine("");
                            Console.WriteLine(currentRoom.GetDescription());
                            Console.WriteLine("");
                            break;

                        case "check room for item": // Checks if the current room has an item and if so adds it to the inventory
                            if (currentRoom.GetItem() == "")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("There are no items in this room.");
                                Console.WriteLine("");
                            }
                            else
                            {
                                player.PickUpItem(currentRoom);
                                Console.WriteLine("");
                                Console.WriteLine("The item has been picked up");
                                Console.WriteLine("");
                            }
                            break;

                        case "check health": // Prints out the health of the player
                            Console.WriteLine("");
                            Console.WriteLine("Player's health is " + player.GetHealth());
                            Console.WriteLine("");
                            break;
    
                        case "check inventory": // Prints out the inventory of the player
                            Console.WriteLine("");
                            Console.WriteLine(player.InventoryContents());
                            Console.WriteLine("");
                            break;
                    }
                }
            }
        }
    }
}
