using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {

        private Player player;
        private Room currentRoom;
        private Room nextRoom;
        private string playerName;

        public Game()
        {
            // Initialized the game with one room and one player
            Console.WriteLine("Enter your character name :");
            playerName = Console.ReadLine();
            while (string.IsNullOrEmpty(playerName))
            {
                Console.Write("Enter your player name :");
                playerName = Console.ReadLine();
            }
            player = new Player(playerName, 30);
            Room room1 = new Room(playerName+" finds themself in an empty room with just a door on the opposite end.", "Worn key",1);
            Room room2 = new Room(playerName+" finds themself in a room full of gold and treasure with another door on the opposite end.", "Gold coin",1);
            currentRoom = room1;
            nextRoom = room2;

        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                // Playing logic
                Console.WriteLine("");
                Console.WriteLine("Your choices are :");
                Console.WriteLine("- room description");
                Console.WriteLine("- open door");
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

                        case "open door":
                            if (currentRoom.CheckDoorLocked() == 1 && player.InventoryContents() != "Worn key")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("The door is locked.");
                                Console.WriteLine("");
                            }
                            else if (currentRoom.CheckDoorLocked() == 1 && player.InventoryContents() == "Worn key") 
                            {
                                Console.WriteLine("");
                                Console.WriteLine("The key broke unlocking the door.");
                                Console.WriteLine(playerName+" opens the door and walks into the next room");
                                Console.WriteLine("");
                                player.UseItem();
                                currentRoom = nextRoom;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine(playerName+" opens the door and walks into the next room");
                                Console.WriteLine("");
                                currentRoom = nextRoom;
                            }
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
                                Console.WriteLine("The item has been picked up.");
                                Console.WriteLine("");
                            }
                            break;

                        case "check health": // Prints out the health of the player
                            Console.WriteLine("");
                            Console.WriteLine(playerName+"'s health is " + player.GetHealth());
                            Console.WriteLine("");
                            break;

                        case "check inventory": // Prints out the inventory of the player
                            Console.WriteLine("");
                            Console.WriteLine(playerName+"'s inventory contains : "+player.InventoryContents());
                            Console.WriteLine("");
                            break;
                    }
                }
            }
        }
    }
}
