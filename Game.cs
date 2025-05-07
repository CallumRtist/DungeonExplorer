using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Policy;
using static System.Collections.Specialized.BitVector32;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private GameMap gameMap;

        public void Start()
        {
            // Boolean for if the game is playing, set to false at start of game and set to false at end of game to end the while loop
            bool playing = false;

            // When S is typed set Playing Boolean to true, while loop for if any other key is pressed
            while (playing == false)
            {
                Console.WriteLine("\nWelcome to Dungeon Explorer! \nYour goal is to earn 1000 gold... \nType S to Start");
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

            Testing.AssertPlayerHasName(player);

            // Loop while Playing Boolean is true
            while (playing)
            {
                var currentRoom = gameMap.GetCurrentRoom();
                bool hasSearched = false;
                bool inRoom = true;

                Monsters.SlimeMonster.Health = 4;
                Monsters.SkeletonMonster.Health = 6;
                Monsters.GhoulMonster.Health = 8;

                Console.Clear();

                // Loop until actions are completed within current room
                while (inRoom)
                {
                    // Winning Condition, earn 1000 gold
                    if (player.Money == 1000)
                    {
                        Console.WriteLine("You Won!!!");
                        inRoom = false;
                        playing = false;
                    }

                    // If the current room does not contain any monsters, then display these options...
                    if (currentRoom.Monster == null || currentRoom.Monster == Monsters.NoEncounter)
                    {
                        Testing.AssertRoomDoesNotHaveMonster(gameMap);

                        Console.WriteLine("\nWhat would you like to do? \n\nType C to check your current stats/room type \nType E to search for items \nType \"Use *Item Name*\" to use an item \nType M to move to another room \nType Q to Quit");

                        Testing.PrintCurrentRoom(gameMap);
                    }
                    // If the current room does contain monsters, then display these options (includes the attack option, removes move and quit options)...
                    else
                    {
                        Testing.AssertRoomHasMonster(gameMap);

                        Console.WriteLine($"\nYou encounter a {currentRoom.Monster.Name}, What would you like to do? \n\nType A to Attack \nType E to check the enemy's stats \nType C to check your current stats/room type \nType \"Use *Item Name*\" to use an item ");

                        Testing.PrintCurrentRoom(gameMap);
                        Testing.PrintCreaturesHealth(player, currentRoom.Monster);
                    }
                    string action = Console.ReadLine().ToLower();

                    // Call player attack method and check if monster health now equals 0, if so run the clear monster method to remove the monster
                    if (action == "a" && (currentRoom.Monster != null || currentRoom.Monster != Monsters.NoEncounter))
                    {
                        Testing.AssertRoomHasMonster(gameMap);

                        player.Attack(currentRoom.Monster);
                        if (currentRoom.Monster.Health <= 0)
                        {
                            Console.WriteLine($"\nYou have defeated the {currentRoom.Monster.Name}!");
                            currentRoom.ClearMonster();

                            Testing.AssertRoomDoesNotHaveMonster(gameMap);
                        }
                        // If the monster has not died, the monster will run its attack method on the player, if the players health equals 0, then quit the game
                        else
                        {
                            Testing.AssertRoomHasMonster(gameMap);

                            currentRoom.Monster.Attack(player);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine("\nYou have died!");
                                inRoom = false;
                                playing = false;
                            }
                        }
                    }

                    // Check the room description, Player health/money/inventory/damage and name
                    if (action == "c")
                    {
                        Console.WriteLine($"\nThe current room is the {currentRoom.GetDescription()}");
                        player.Stats();
                        player.inventory.InventoryContents();
                        Console.WriteLine("\n");
                    }

                    // Search the Room for items, run pick up item method if there is an item, return message if room already searched
                    if (action == "e")
                    {
                        if (currentRoom.Monster == null)
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
                        else
                        {
                            currentRoom.Monster.Stats();
                        }
                    }

                    // Use item, checks player has the item and removes the item from the list after use
                    if (action == "use health potion")
                    {
                        if (player.inventory.GetItems().Contains(Items.healthItem))
                        {
                            player.Health += Items.healthItem.Restoration;
                            Console.WriteLine("\nYou used the Health Potion and gained 5 health!\n");
                            player.RemoveItem(Items.healthItem);
                        }
                        else
                        {
                            Console.WriteLine("\nYou do not have a health potion...");
                        }
                    }
                    if (action == "use bag of money")
                    {
                        if (player.inventory.GetItems().Contains(Items.moneyItem))
                        {
                            player.Money += Items.moneyItem.MoneyAdd;
                            Console.WriteLine("\nYou opened the Bag of Money and got 25 coins!\n");
                            player.RemoveItem(Items.moneyItem);
                        }
                        else
                        {
                            Console.WriteLine("\nYou do not have a bag of money...");
                        }
                    }
                    if (action == "use treasure chest")
                    {
                        if (player.inventory.GetItems().Contains(Items.chestItem))
                        {
                            player.Money += Items.chestItem.MoneyAdd;
                            Console.WriteLine("\nYou opened the Treasure Chest and found 100 coins!!!\n");
                            player.RemoveItem(Items.chestItem);
                        }
                        else
                        {
                            Console.WriteLine("\nYou do not have a treasure chest...");
                        }
                    }

                    // Move to another room and choose a direction, call GameMap Move method using direction inputted
                    if (action == "m" && currentRoom.Monster == null)
                    {
                        Console.WriteLine("\nWhich direction would you like to go? \nType Up, Down, Left or Right");
                        string direction = Console.ReadLine().ToLower();

                        gameMap.Move(direction);

                        inRoom = false;
                    }

                    // If player types Q, quit the game
                    if (action == "q" && currentRoom.Monster == null)
                    {
                        inRoom = false;
                        playing = false;
                    }
                }
            }
        }
    }
}