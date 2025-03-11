using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private int _health;
        private int _money;


        public string Name { get; private set; }
        public int Health
        {
            // Prevent Health from being below 0 or above 10
            get { return _health; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > 10)
                {
                    value = 10;
                }
                _health = value;
            }
        }
        public int Money 
        { 
            // Prevent Money from being below 0
            get { return _money; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _money = value;
            }
        
        }


        public List<Item> inventory { get; private set; } = new List<Item>();

        // Player Class Attributes
        public Player(string name, int health, int money) 
        {
            Name = name;
            Health = health;
            Money = money;
        }

        // When PickUpItem is called, add 1 to the quantity value of that item, and add the item if not in Inv.
        public void PickUpItem(Item item)
        {
            item.Quantity += 1;
            if (inventory.Contains(item) == false)
            {
                inventory.Add(item);
            }
        }

        // When RemoveItem is called, take 1 from the quantity of that item, and remove it from Inv. if 0
        public void RemoveItem(Item item)
        {
            item.Quantity -= 1;
            if (item.Quantity == 0)
            {
                inventory.Remove(item);
            }
        }

        // When InventoryContents is called, display the name, quantity and value of each item added to the Inv.
        public void InventoryContents()
        {
            Console.WriteLine("You have...");
            foreach (Item item in inventory)
            {
                Console.WriteLine($"{item.Name} x{item.Quantity}: {item.Value}");
            }
        }

        // When PlayerStats is called, display the Players chosen Name, their current Health and the amount of Money they have
        public void PlayerStats()
        {
            Console.WriteLine($"Your name is {Name}");
            Console.WriteLine($"Your current health is {Health}/10");
            Console.WriteLine($"You have {Money} coins");
            
        }
    }
}