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
        private Room currentRoom;
        private List<string> roomList;
        private List<Item> itemList;
        private List<Item> randomItems;
        private Random randomClass = new Random();

        public Game()
        {
            // Create list of all Rooms
            roomList = new List<string>() 
            { "Starter Room","Second Room","Third Room","Fourth Room","Fifth Room","Sixth Room","Seventh Room","Eighth Room","Ninth Room","Final Room" };

            // Create all item types
            Item healthItem = new Item("Health Potion", 5);
            Item moneyItem = new Item("Bag of Money", 25);
            Item chestItem = new Item("Treasure Chest", 1000);

            // Create list of all items & a list of all items which can be randomly found in each room
            itemList = new List<Item>() { healthItem, moneyItem, chestItem };
            randomItems = new List<Item>() { healthItem, moneyItem, null };

        }

        // When called on, generate an interger from 0 - 2 and use to select an item from the randomItems list (generate a random item)
        public Item GenerateItem()
        {
            int randomItem = randomClass.Next(3);
            return randomItems[randomItem];
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

            player = new Player(playerName, playerHealth, 0);

            // Loop while Playing Boolean is true
            while (playing)
            {
                currentRoom = new Room("Starter Room", GenerateItem());

                // Loop for each Room Name in roomList until reaching final room (get Room name)
                foreach (string roomDesc in roomList)
                {
                    bool hasSearched = false;
                    bool inRoom = true;
                    currentRoom = new Room(roomDesc, GenerateItem());
                    Console.WriteLine($"\nYou find yourself within the {currentRoom.GetDescription()}");

                    // Loop until actions are completed within current room
                    while (inRoom)
                    {

                        
                        Console.WriteLine("What would you like to do? \n\nType C to check your current stats/room type \nType E to search for items \nType \"Use *Item Name*\" to use an item \nType W to go to the next room");
                        string action = Console.ReadLine().ToLower();

                        // Check the room description, Player health/money/inventory and name
                        if (action == "c")
                        {
                            Console.WriteLine($"\nThe current room is the {currentRoom.GetDescription()}");
                            player.PlayerStats();
                            player.InventoryContents();
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

                                // Will give Treasure Item in the Final Room
                                if (roomDesc == "Final Room")
                                {
                                    Console.WriteLine("\nYou searched the room and found... ");
                                    Console.WriteLine("...a Treasure Chest!!!");
                                    player.PickUpItem(itemList[2]);
                                    hasSearched = true;
                                }
                            }
                        }

                        // Use Item
                        if (action == "use health potion")
                        {
                            player.Health += itemList[0].Value;
                            Console.WriteLine("\nYou used the Health Postion and gained 5 health!\n");
                            player.RemoveItem(itemList[0]);
                        }
                        if (action == "use bag of money")
                        {
                            player.Money += itemList[1].Value;
                            Console.WriteLine("\nYou opened the Bag of Money and got 25 coins!\n");
                            player.RemoveItem(itemList[1]);
                        }
                        if (action == "use treasure chest")
                        {
                            player.Money += itemList[2].Value;
                            Console.WriteLine("\nYou opened the Treasure Chest and found 1000 coins!!!\n");
                            player.RemoveItem(itemList[2]);
                        }

                        // Go to the next Room, if Final Room then quit game by setting Playing Boolean to false
                        if (action == "w")
                        {
                            if (roomDesc == "Final Room")
                            {
                                Console.WriteLine("\nYou Escaped!");
                                playing = false;
                            }
                            inRoom = false;
                            
                        }
                    }
                }
                


            }
        }
    }
}