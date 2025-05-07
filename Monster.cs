using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Attributes
    // Name, Health, Damage

    // Methods
    // Attack

    public class Monster : Creature
    {
        // Monster Constructor
        public Monster(string name, int health, int damage) : base(name, health, damage)
        {
            
        }

        // When Attack is called, take away the value of the monster's damage from the player's health
        public override void Attack(Creature player)
        {
            if (!(player is Player))
            {
                Console.WriteLine("Enemy must be the player");
                return;
            }
            player.Health -= Damage;
            Console.WriteLine($"You take {Damage} damage from the enemy");
        }
    }
}
