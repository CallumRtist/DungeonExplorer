using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // Attributes
    // Name, Health, Damage, Money

    // Methods
    // PickUpItem, RemoveItem, InventoryContents, Attack, Stats

    public class Player : Creature
    {
        // Private Properties
        private int _money;

        // Public Properties
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
        public Inventory inventory { get; private set; } = new Inventory();

        // Player Constructor
        public Player(string name, int health, int damage, int money) : base(name, health, damage)
        {
            Money = money;
        }

        // When Attack is called, take away the value of player damage from the monster's health
        public override void Attack(Creature monster)
        {
            if (!(monster is Monster))
            {
                Console.WriteLine("Enemy must be a monster");
                return;
            }
            monster.Health -= Damage;
            Console.WriteLine($"You inflict {Damage} damage to the enemy");
        }

        // When Stats is called, display the Players chosen Name, their current Health, the amount of damage they do and the amount of Money they have
        public override void Stats()
        {
            Console.WriteLine($"Your name is {Name}");
            Console.WriteLine($"Your current health is {Health}/10");
            Console.WriteLine($"You do {Damage} damage");
            Console.WriteLine($"You have {Money} coins");
        }

        // When PickUpItem is called, add 1 to the quantity value of that item, and add the item if not in Inv.
        public void PickUpItem(Item item)
        {
            inventory.AddItem(item);
        }

        // When RemoveItem is called, take 1 from the quantity of that item, and remove it from Inv. if 0
        public void RemoveItem(Item item)
        {
            inventory.RemoveItem(item);
        }
    }
}