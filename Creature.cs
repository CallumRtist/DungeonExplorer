using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    abstract class Creature
    {
        private string _name;
        private int _health;
        private int _damage;

        public string Name
        {
            // Prevent Name from being empty
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public int Health
        {
            // Prevent Health from being below 0 or above 10
            get => _health;
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

        public int Damage
        {
            // Prevents Damage from being less than 0 or above 10
            get => _damage;
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
                _damage = value;
            }
        }

        // Constructor
        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        // Attack method, defined individually
        public abstract void Attack();

        // Stats method, defaults to this but can be overwritten
        public virtual void Stats()
        {
            Console.WriteLine($"The creature is: {Name}");
            Console.WriteLine($"Their current health is {Health}/10");
            Console.WriteLine($"They do {Damage} damage");
        }
    }
}
