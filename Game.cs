using System;
using System.Collections.Generic;
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

        public Game()
        {
            // Create list of all Rooms
            roomList = new List<string>() 
            { "Starter Room","Second Room","Third Room","Fourth Room","Fifth Room","Sixth Room","Seventh Room","Eighth Room","Ninth Room","Final Room" };

            // Create all item types
            Item healthItem = new Item("Health Potion", 5);
            Item moneyItem = new Item("Bag of Money", 25);
            Item chestItem = new Item("Treasure Chest", 1000);

            // Create list of all items
            itemList = new List<Item>() { healthItem, moneyItem, chestItem };

        }

        public void Start()
        {
            // Boolean for if the game is playing, set to false at start of game and set to false at end of game to end the while loop
            bool playing = false;

            // When S is typed set Playing Boolean to true, while loop for if any other key is pressed
            while (playing == false)
            {
                Console.WriteLine("\nWelcome to Dungeon Explorer \nType S to Start");
                string start = Console.ReadLine();
                if (start == "S")
                {
                    playing = true;
                }
            }

            // Setting Player Name and Health
            string playerName = "";

            while (playerName == "")
            {
                Console.WriteLine("\nEnter a name:");
                playerName = Console.ReadLine();
            }

            int playerHealth = 10;

            player = new Player(playerName, playerHealth, 0);

            // Loop while Playing Boolean is true
            while (playing)
            {
                currentRoom = new Room("Starter Room");

                // Loop for each Room Name in roomList until reaching final room (get Room name)
                foreach (string roomDesc in roomList)
                {
                    bool hasSearched = false;
                    bool inRoom = true;
                    currentRoom = new Room(roomDesc);
                    Console.WriteLine($"\nYou find yourself within the {currentRoom.GetDescription()}");

                    // Loop until actions are completed within current room
                    while (inRoom)
                    {

                        
                        Console.WriteLine("What would you like to do? \n\nType C to check your current stats/room type \nType E to search for items \nType \"Use *Item Name*\" to use an item \nType W to go to the next room");
                        string action = Console.ReadLine();

                        // Check the room description, Player health/money/inventory and name
                        if (action == "C")
                        {
                            Console.WriteLine($"\nThe current room is the {currentRoom.GetDescription()}");
                            player.PlayerStats();
                            player.InventoryContents();
                            Console.WriteLine("\n");
                        }
                        // Search the Room for items, return message if already searched
                        if (action == "E")
                        {
                            if (hasSearched == true)
                            {
                                Console.WriteLine("\nYou have already searched this room\n");
                            }

                            if (hasSearched == false)
                            {
                                // Will give Health Item in the 1st, 4th and 7th rooms
                                if (roomDesc == "Starter Room" || roomDesc == "Fourth Room" || roomDesc == "Seventh Room")
                                {
                                    Console.WriteLine("\nYou searched the room and found... ");
                                    Console.WriteLine("...a Health Potion!");
                                    player.PickUpItem(itemList[0]);
                                    hasSearched = true;
                                }

                                // Will give nothing in the 2nd, 5th and 8th rooms
                                if (roomDesc == "Second Room" || roomDesc == "Fifth Room" || roomDesc == "Eighth Room")
                                {
                                    Console.WriteLine("\nYou searched the room and found... ");
                                    Console.WriteLine("...nothing");
                                    hasSearched = true;
                                }

                                // Will give Money Item in the 3rd, 6th and 9th rooms
                                if (roomDesc == "Third Room" || roomDesc == "Sixth Room" || roomDesc == "Ninth Room")
                                {
                                    Console.WriteLine("\nYou searched the room and found... ");
                                    Console.WriteLine("...a Bag of Money!");
                                    player.PickUpItem(itemList[1]);
                                    hasSearched = true;
                                }

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
                        if (action == "Use Health Potion")
                        {
                            player.Health += itemList[0].Value;
                            Console.WriteLine("\nYou used the Health Postion and gained 5 health!\n");
                            player.RemoveItem(itemList[0]);
                        }
                        if (action == "Use Bag of Money")
                        {
                            player.Money += itemList[1].Value;
                            Console.WriteLine("\nYou opened the Bag of Money and got 25 coins!\n");
                            player.RemoveItem(itemList[1]);
                        }
                        if (action == "Use Treasure Chest")
                        {
                            player.Money += itemList[2].Value;
                            Console.WriteLine("\nYou opened the Treasure Chest and found 1000 coins!!!\n");
                            player.RemoveItem(itemList[2]);
                        }

                        // Go to the next Room, if Final Room then quit game by setting Playing Boolean to false
                        if (action == "W")
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