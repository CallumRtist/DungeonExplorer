using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Monsters
    {
        // Instantiate Monster Class, creating 3 new monsters of increasing difficulty
        public static readonly Monster SlimeMonster = new Monster("Slime", 4, 1);
        public static readonly Monster SkeletonMonster = new Monster("Skeleton", 6, 2);
        public static readonly Monster GhoulMonster = new Monster("Ghoul", 8, 3);

        // Creates an empty(null) monster class called no encounter so theres a chance of finding no enemies
        public static readonly Monster NoEncounter = null;

        // Create a new array called 'All' to store created monsters
        public static Monster[] All = new[] { SlimeMonster, SkeletonMonster, GhoulMonster, NoEncounter };

        // Instantiates the random class
        private static Random rand = new Random();

        // Method that gets a random monster from the array when called
        public static Monster GetRandom()
        {
            var randIndex = rand.Next(All.Length);
            return All[randIndex];
        }
    }
}
