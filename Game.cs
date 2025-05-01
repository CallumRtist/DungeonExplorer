using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private GameMap gameMap;

        public Game()
        {

        }

        public void Start()
        {
            // Boolean for if the game is playing, set to false at start of game and set to false at end of game to end the while loop
            bool playing = false;

            // When S is typed set Playing Boolean to true, while loop for if any other key is pressed
            while (playing == false)
            {
                Console.WriteLine("\nWelcome to Dungeon Explorer \nType S to Start");
                string start = Console.ReadLine().ToLower();
                if (start == "s")
                {
                    playing = true;
                }
            }

            // Setting player Name, prevents the player from entering nothing, spaces and/or numbers & special characters
            string playerName = "";

            while (playerName == "")
            {
                Console.WriteLine("\nEnter a name:");
                playerName = Console.ReadLine();
                if (playerName.Any(char.IsWhiteSpace))
                {
                    playerName = "";
                    Console.WriteLine("\nName cannot contain spaces");
                }
                if (playerName.All(char.IsLetter) == false)
                {
                    playerName = "";
                    Console.WriteLine("\nName cannot contain numbers or special characters");
                }
            }

            // Setting Player Name, Health and Money
            int playerHealth = 10;

            player = new Player(playerName, playerHealth, 2, 0);
            gameMap = new GameMap(Rooms.StartRoom);

            // Loop while Playing Boolean is true
            while (playing)
            {
                var currentRoom = gameMap.GetCurrentRoom();
                bool hasSearched = false;
                bool inRoom = true;

                // Loop until actions are completed within current room
                while (inRoom)
                {

                    Console.WriteLine("What would you like to do? \n\nType C to check your current stats/room type \nType E to search for items \nType \"Use *Item Name*\" to use an item \nType M to move to another room \nType Q to Quit");
                    string action = Console.ReadLine().ToLower();

                    // Check the room description, Player health/money/inventory and name
                    if (action == "c")
                    {
                        Console.WriteLine($"\nThe current room is the {currentRoom.GetDescription()}");
                        player.Stats();
                        player.inventory.InventoryContents();
                        Console.WriteLine("\n");
                    }
                    // Search the Room for items, get a random item from randomItem list, return message if room already searched
                    if (action == "e")
                    {
                        if (hasSearched == true)
                        {
                            Console.WriteLine("\nYou have already searched this room\n");
                        }

                        if (hasSearched == false)
                        {
                            Console.WriteLine("\nYou searched the room and found... ");

                            if (currentRoom.Item != null)
                            {
                                Console.WriteLine($"...a {currentRoom.Item.Name}!");
                                player.PickUpItem(currentRoom.Item);
                            }
                            else
                            {
                                Console.WriteLine("...nothing");
                            }

                            hasSearched = true;

                        }
                    }

                    // Use Item
                    if (action == "use health potion")
                    {
                        player.Health += Items.healthItem.Value;
                        Console.WriteLine("\nYou used the Health Postion and gained 5 health!\n");
                        player.RemoveItem(Items.healthItem);
                    }
                    if (action == "use bag of money")
                    {
                        player.Money += Items.moneyItem.Value;
                        Console.WriteLine("\nYou opened the Bag of Money and got 25 coins!\n");
                        player.RemoveItem(Items.moneyItem);
                    }
                    if (action == "use treasure chest")
                    {
                        player.Money += Items.chestItem.Value;
                        Console.WriteLine("\nYou opened the Treasure Chest and found 1000 coins!!!\n");
                        player.RemoveItem(Items.chestItem);
                    }

                    // Move to another room and choose a direction, call GameMap Move method using direction inputted
                    if (action == "m")
                    {
                        Console.WriteLine("Which direction would you like to go? \nType Up, Down, Left or Right");
                        string direction = Console.ReadLine().ToLower();

                        gameMap.Move(direction);

                        inRoom = false;
                    }

                    // If player types Q, quit the game
                    if (action == "q")
                    {
                        inRoom = false;
                        playing = false;
                    }
                }
            }
        }
    }
}